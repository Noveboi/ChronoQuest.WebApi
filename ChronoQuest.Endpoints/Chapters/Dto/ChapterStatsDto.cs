namespace ChronoQuest.Endpoints.Chapters.Dto;

internal sealed record StatsPerChapterDto; 
internal sealed record ChapterStatsDto(IEnumerable<StatsPerChapterDto> PerChapter);