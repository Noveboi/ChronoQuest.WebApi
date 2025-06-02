namespace ChronoQuest.Endpoints.Chapters.Dto;

internal sealed record ChapterReadingWithoutIdDto(DateTime Start, double SecondsRead);
internal sealed record ChapterReadingDto(Guid ChapterId, DateTime Start, double SecondsRead);