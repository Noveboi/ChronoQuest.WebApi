using ChronoQuest.Core.Domain.Stats;
using ChronoQuest.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Core.Application.Chapters;

public sealed record StatsPerChapter(IEnumerable<ChapterReadingTime> Readings, TimeSpan TotalDuration);

public sealed class ChapterStatsService(ChronoQuestContext context)
{
    public async Task<ChapterStats> GetChapterStatsAsync(Guid userId, CancellationToken ct)
    {
        var readings = await context.ChapterReadings
            .AsNoTracking()
            .Include(x => x.Chapter)
            .ThenInclude(x => x.Topic)
            .Where(x => x.UserId == userId)
            .GroupBy(x => x.ChapterId)
            .ToListAsync(ct);

        return new ChapterStats(
            Chapters: readings.ToDictionary(
                keySelector: x => x.First(r => r.Chapter.Id == x.Key).Chapter,
                elementSelector: x => new StatsPerChapter(
                    Readings: x.Select(t => t),
                    TotalDuration: TimeSpan.FromSeconds(x.Sum(t => t.TotalSeconds)))));
    }
}