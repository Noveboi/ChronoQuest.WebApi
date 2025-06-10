using ChronoQuest.Common;
using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Interfaces;

namespace ChronoQuest.Core.Domain.Stats;

public sealed class QuestionReadingTime : Entity, ITimeTrackingEntity<QuestionReadingTime>
{
    private QuestionReadingTime() { }
    private QuestionReadingTime(Guid userId, Guid questionId, DateTimeOffset startedAt, TimeSpan duration)
    {
        UserId = userId;
        QuestionId = questionId;
        StartedAt = startedAt;
        Duration = duration;
    }
    
    public Guid UserId { get; private init; }
    public Guid QuestionId { get; private init; }
    public DateTimeOffset StartedAt { get; private set; }
    public TimeSpan Duration { get; private set; }

    public Question Question { get; private init; } = null!;
    
    public static QuestionReadingTime FromData(TimeTrackingInformation info, Guid userId)
    {
        return new QuestionReadingTime(
            userId: userId,
            questionId: info.EntityId,
            startedAt: info.TrackingStartUtc,
            duration: info.Duration);
    }
}