namespace ChronoQuest.Endpoints.Chapters.Dto;

internal sealed record ChapterPreviewDto(
    Guid Id, 
    string Title, 
    string Topic, 
    int Order,
    int ReadSeconds,
    IEnumerable<ChapterPreviewQuestionDto> Questions);

internal sealed record ChapterPreviewQuestionDto(
    Guid Id,
    string Status);