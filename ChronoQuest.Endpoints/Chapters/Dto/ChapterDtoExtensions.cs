using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Endpoints.Chapters.Dto;

internal static class ChapterDtoExtensions
{
    public static ChapterDto ToDto(this Chapter chapter) => new(
        Id: chapter.Id,
        Title: chapter.Title,
        Topic: chapter.Topic.Name,
        Content: chapter.Content);
}