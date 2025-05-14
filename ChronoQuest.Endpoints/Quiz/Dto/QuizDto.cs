namespace ChronoQuest.Endpoints.Quiz.Dto;

internal sealed record QuizDto(IEnumerable<QuestionPreviewDto> Questions);