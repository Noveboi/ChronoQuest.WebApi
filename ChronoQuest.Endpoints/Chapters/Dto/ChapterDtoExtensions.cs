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
        Content: chapter.Content,
        Order: chapter.Order);

    public static ChapterPreviewDto ToPreviewDto(this Chapter chapter, int totalReadSeconds, List<Question> questions) => new(
        Id: chapter.Id,
        Title: chapter.Title,
        Topic: chapter.Topic.Name,
        Order: chapter.Order,
        ReadSeconds: totalReadSeconds,
        Questions: questions.Select(q => new ChapterPreviewQuestionDto(
            Id: q.Id,
            Status: q.Status.ToString())));
    
    public static ChapterReadingDto ToDto(this ChapterReadingTime reading) => new(
        ChapterId: reading.ChapterId,
        Start: reading.StartedAtUtc,
        SecondsRead: reading.TotalSeconds);

    public static ChapterStatsDto ToDto(this ChapterStats stats) => new(
        stats.Chapters.Select(x => new StatsPerChapterDto()));
}