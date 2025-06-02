namespace ChronoQuest.Core.Domain.Stats;

public sealed class ChapterReadingTime : Entity
{
    private ChapterReadingTime() { }

    public ChapterReadingTime(Guid userId, Guid chapterId, DateTimeOffset startedAt, TimeSpan duration)
    {
        UserId = userId;
        ChapterId = chapterId;
        StartedAtUtc = startedAt.UtcDateTime;
        Duration = duration;
    }
    
    public Guid UserId { get; private init; }
    public Guid ChapterId { get; private init; }
    
    public DateTime StartedAtUtc { get; private init; }
    public TimeSpan Duration { get; private init; }
}