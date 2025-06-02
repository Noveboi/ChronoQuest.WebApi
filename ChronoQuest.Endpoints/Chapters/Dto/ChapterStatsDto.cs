namespace ChronoQuest.Endpoints.Chapters.Dto;

internal sealed record StatsPerChapterDto(
    ChapterPreviewDto Chapter,
    IEnumerable<ChapterReadingWithoutIdDto> Readings,
    double TotalSecondsRead); 
internal sealed record ChapterStatsDto(IEnumerable<StatsPerChapterDto> PerChapter);