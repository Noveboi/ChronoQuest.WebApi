namespace ChronoQuest.Endpoints.Chapters.Dto;

internal sealed record ReadingTimePerDayDto(DateOnly Date, double TotalSeconds);
internal sealed record ChapterStatsDto(
    SlimChapterDto Chapter, 
    IEnumerable<ReadingTimePerDayDto> ReadingTimePerDay,
    double TotalReadingTime);