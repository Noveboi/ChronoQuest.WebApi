namespace ChronoQuest.Endpoints.Chapters.Dto;

internal sealed record ChapterReadingWithoutIdDto(DateTime Start, TimeSpan Duration);
internal sealed record ChapterReadingDto(Guid ChapterId, DateTime Start, TimeSpan Duration);