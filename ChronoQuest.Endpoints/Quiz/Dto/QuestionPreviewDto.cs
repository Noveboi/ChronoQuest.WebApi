namespace ChronoQuest.Endpoints.Quiz.Dto;

internal sealed record QuestionPreviewDto(
    Guid Id, 
    int Number, 
    string Type,
    string Status);