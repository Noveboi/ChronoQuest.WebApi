using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Domain.Interfaces;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace ChronoQuest.Endpoints.Exam;

public sealed record ExamTimer(TimeSpan ElapsedTime, TimeSpan Limit) : ITimeTrackingEntity<ExamTimer>
{
    public static ExamTimer FromData(TimeTrackingInformation info, Guid userId)
    {
        return new ExamTimer(info.Duration, TimeSpan.FromMinutes(15));
    }
}

public class AnswerExamQuestionEndpoint(ITimeTracker<ExamTimer> timeTracker) : EndpointWithoutRequest
{
    // IMPORTANTE:
    // - ITimeTracker GetTimeElapsed() για να δεις αν εχει λήξει ο χρόνος (με βάση 

    public override async Task HandleAsync(CancellationToken ct)
    {
        var stats = await timeTracker.GetTrackingInfoAsync(req.UserId, req.ExamId, ct);
        if (stats is null)
        {
            var invalid = Result.Invalid(new ValidationError("Exam is not being tracked."));
            await SendResultAsync(invalid.ToMinimalApiResult());
            return;
        }

        if (stats.ElapsedTime > stats.Limit)
        {
            var invalid = Result.Invalid(new ValidationError("You've run out of time!"));
            await SendResultAsync(invalid.ToMinimalApiResult());
            return;
        }
        
        // ... Continue here.
    }
}