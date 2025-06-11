using System.Security.Claims;
using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints.Utilities.Attributes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChronoQuest.Endpoints.Exam;

internal sealed record AnswerExamQuestionRequest(
    [property: UserId] Guid UserId,
    [property: RouteParam] Guid ExamId);

internal sealed class AnswerExamQuestionEndpoint(
    ChronoQuestContext context, 
    ITimeTracker<ExamTimer> timeTracker) : Endpoint<AnswerExamQuestionRequest>
{
    public override void Configure()
    {
        Get("todo");
        // ‼️Add route!
    }

    public override async Task HandleAsync(AnswerExamQuestionRequest req, CancellationToken ct)
    {
        var stats = await timeTracker.GetTrackingInfoAsync(req.UserId, req.ExamId, ct);
        if (stats is null)
        {
            await SendErrorAsync("Exam is not being tracked!");
            return;
        }

        var exam = await context.Exams
            .Select(x => new { x.TimeLimit, x.UserId })
            .FirstOrDefaultAsync(x => x.UserId == req.UserId, ct);

        if (exam is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        if (stats.ElapsedTime > exam.TimeLimit)
        {
            await SendErrorAsync("You've run out of time!");
            return;
        }
        
        // ... Continue here.
    }

    private Task SendErrorAsync(string error)
    {
        Logger.LogError("Sending {error}", error);
        return SendResultAsync(Result.Invalid(new ValidationError(error)).ToMinimalApiResult());
    }
}