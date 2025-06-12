using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Application.Chapters.Models;

public sealed record StatsPerChapter(Chapter Chapter, IEnumerable<ReadingTimePerDay> Readings)
{
    public TimeSpan TotalDuration => Readings.Aggregate(TimeSpan.Zero, (t, r) => t + r.Duration);
}