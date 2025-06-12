using ChronoQuest.Core.Application.Chapters.Models;
using ChronoQuest.Core.Domain.Stats;
using ChronoQuest.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Core.Application.Chapters;

public sealed class ChapterStatsService(ChronoQuestContext context)
{
    public async Task<IEnumerable<StatsPerChapter>> GetChapterStatsAsync(Guid userId, CancellationToken ct)
    {
        var readingsGroup = await context.ChapterReadings
            .AsNoTracking()
            .Include(x => x.Chapter)
            .ThenInclude(x => x.Topic)
            .Where(x => x.UserId == userId)
            .GroupBy(x => x.ChapterId)
            .ToListAsync(ct);

        return readingsGroup.Select(group => new StatsPerChapter(
                Chapter: group.First().Chapter,
                Readings: group
                    .GroupBy(x => DateOnly.FromDateTime(x.StartedAtUtc))
                    .Select(x => new ReadingTimePerDay(
                            Date: x.Key,
                            Duration: TimeSpan.FromSeconds(x.Aggregate(0.0, (y, r) => y + r.TotalSeconds))))));
    }
}