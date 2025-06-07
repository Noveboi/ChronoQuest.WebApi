namespace ChronoQuest.Endpoints.Chapters.Dto;

internal sealed record ChapterDto(Guid Id, string Title, string Content, string Topic, int Order);