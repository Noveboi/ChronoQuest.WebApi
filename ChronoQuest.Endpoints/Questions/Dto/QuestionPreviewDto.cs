namespace ChronoQuest.Endpoints.Questions.Dto;

internal sealed record QuestionPreviewDto(
    Guid Id, 
    string Type,
    string Status,
    string Topic,
    string Difficulty);