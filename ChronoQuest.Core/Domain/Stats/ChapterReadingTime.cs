using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Interfaces;

namespace ChronoQuest.Core.Domain.Stats;

public sealed class ChapterReadingTime : Entity, ITimeTrackingEntity<ChapterReadingTime>
{
    private ChapterReadingTime() { }
    private ChapterReadingTime(Guid userId, Guid chapterId, DateTimeOffset startedAt, TimeSpan duration)
    {
        UserId = userId;
        ChapterId = chapterId;
        StartedAtUtc = startedAt.UtcDateTime;
        Duration = duration;
    }
    
    public Guid UserId { get; private init; }
    public Guid ChapterId { get; private init; }
    public Chapter Chapter { get; private init; } = null!;
    
    public DateTime StartedAtUtc { get; private init; }
    public TimeSpan Duration { get; private init; }
    public static ChapterReadingTime FromData(TimeTrackingInformation info, Guid userId)
    {
        return new ChapterReadingTime(
            userId: userId, 
            chapterId: info.EntityId, 
            startedAt: info.TrackingStartUtc, 
            duration: info.Duration);
    }
}