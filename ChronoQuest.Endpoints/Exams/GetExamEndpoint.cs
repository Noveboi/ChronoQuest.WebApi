using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using ChronoQuest.Core.Application.Exams;
using ChronoQuest.Core.Application.Markers;
using ChronoQuest.Core.Application.Progress;
using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Domain;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Stats;
using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints.Exams.Dto;
using ChronoQuest.Endpoints.Questions.Dto;
using ChronoQuest.Endpoints.Utilities;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChronoQuest.Endpoints.Exams;

internal sealed class GetExamEndpoint(
    ChronoQuestContext dbContext,
    ExamGenerator generator,
    ITimeTracker<ExamTimeInformation> tracker,
    IProgressQueries progress,
    IMarkerService marker) : Endpoint<GetRequest, ExamDto>
{
    public override void Configure()
    {
        Get("exam");
    }

    public override async Task HandleAsync(GetRequest req, CancellationToken ct)
    {
        var exam = await dbContext.Exams
            .Include(e => e.Questions)
            .WithAnswersOf(req.UserId)
            .Include(e => e.Questions)
            .ThenInclude(q => q.Topic)
            .AsSplitQuery()
            .FirstOrDefaultAsync(e => e.UserId == req.UserId, ct);

        exam ??= await GenerateExam(req, ct);
        if (exam == null)
            return;
        
        var examDto = new ExamDto(
            Id: exam.Id,
            Questions: exam.Questions.Select(q => q.ToPreviewDto(req.UserId)),
            TimeLimitInSeconds: exam.TimeLimit.TotalSeconds);

        await marker.UpsertAsync(new UpdateUserMarkerRequest(req.UserId, exam.Id, UserIs.TakingExam), ct);
        await tracker.TrackAsync(req.UserId, exam.Id, ct);
        await SendAsync(examDto, cancellation: ct);
    }

    private async Task<Exam?> GenerateExam(GetRequest req, CancellationToken ct)
    {
        Logger.LogInformation("Generating exam for user.");

        var chapterValidation = await progress.HasCompletedAllChapters(req.UserId, ct);
        var reviewValidation = await progress.HasCompletedReviewMaterial(req.UserId, ct);

        if (!chapterValidation.IsSuccess || !reviewValidation.IsSuccess)
        {
            await SendResultAsync(Result.Invalid(
                    chapterValidation.ValidationErrors.Concat(reviewValidation.ValidationErrors))
                .ToMinimalApiResult());

            return null;
        }
        
        var exam = await generator.GenerateAsync(req.UserId, ct);
        dbContext.Add(exam);
        await dbContext.SaveChangesAsync(ct);

        return exam;
    }
}