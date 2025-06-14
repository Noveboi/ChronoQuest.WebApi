using System.Security.Claims;
using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using ChronoQuest.Core.Application.Markers;
using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Domain;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Stats;
using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints.Questions.Dto;
using ChronoQuest.Endpoints.Utilities.Attributes;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChronoQuest.Endpoints.Exams;

internal sealed record AnswerExamQuestionRequest(
    [property: UserId] Guid UserId,
    [property: RouteParam] Guid ExamId,
    [property: RouteParam] Guid QuestionId,
    [property: RouteParam] Guid OptionId);

internal sealed class AnswerExamQuestionEndpoint(
    ChronoQuestContext context, 
    ITimeTracker<ExamTimeInformation> timeTracker,
    IQuestionService questionService,
    IMarkerService marker) : Endpoint<AnswerExamQuestionRequest, QuestionDto>
{
    public override void Configure()
    {
        Get("exams/{examId:guid}/questions/{questionId:guid}/answer/{optionId:guid}");
    }

    public override async Task HandleAsync(AnswerExamQuestionRequest req, CancellationToken ct)
    {
        var stats = await timeTracker.GetTrackingInfoAsync(req.UserId, req.ExamId, ct);
        if (stats is null)
        {
            await SendErrorAsync("You are not taking an exam!");
            return;
        }

        var exam = await context.Exams
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

        var request = new AnswerQuestionRequest(QuestionId: req.QuestionId, UserId: req.UserId, ChosenOptionId: req.OptionId);
        var result = await questionService.AnswerQuestionAsync(request, ct);
        if (result.Value is not { } question)
        {
            await SendResultAsync(result.ToMinimalApiResult());
            return;
        }

        if (AnsweredEveryQuestion(exam, req.UserId))
        {
            Logger.LogInformation("User finished exam!");
            await marker.UpsertAsync(new UpdateUserMarkerRequest(req.UserId, req.QuestionId, UserIs.Done), ct);
        }
        
        await SendAsync(question.ToDto(req.UserId), cancellation: ct);
    }

    private Task SendErrorAsync(string error)
    {
        Logger.LogError("Sending {error}", error);
        return SendResultAsync(Result.Invalid(new ValidationError(error)).ToMinimalApiResult());
    }

    private bool AnsweredEveryQuestion(Exam exam, Guid userId) =>
        exam.Questions.All(q => q.Status(userId) is not QuestionStatus.Unanswered);
}