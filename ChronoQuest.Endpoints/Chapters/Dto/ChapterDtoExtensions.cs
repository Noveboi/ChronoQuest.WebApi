using ChronoQuest.Core.Application.Chapters;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Stats;

namespace ChronoQuest.Endpoints.Chapters.Dto;

internal static class ChapterDtoExtensions
{
    public static ChapterDto ToDto(this Chapter chapter) => new(
        Id: chapter.Id,
        Title: chapter.Title,
        Topic: chapter.Topic.Name,
        Content: chapter.Content);

    public static ChapterPreviewDto ToPreviewDto(this Chapter chapter) => new(
        Id: chapter.Id,
        Title: chapter.Title,
        Topic: chapter.Topic.Name);
    
    public static ChapterReadingDto ToDto(this ChapterReadingTime reading) => new(
        ChapterId: reading.ChapterId,
        Start: reading.StartedAtUtc,
        SecondsRead: reading.Duration.TotalSeconds);

    public static ChapterStatsDto ToDto(this ChapterStats stats) => new(
        stats.Chapters.Select(x => new StatsPerChapterDto(
            Chapter: x.Key.ToPreviewDto(),
            Readings: x.Value.Readings.Select(r => new ChapterReadingWithoutIdDto(r.StartedAtUtc, r.Duration.TotalSeconds)),
            TotalSecondsRead: x.Value.TotalDuration.TotalSeconds)));
}