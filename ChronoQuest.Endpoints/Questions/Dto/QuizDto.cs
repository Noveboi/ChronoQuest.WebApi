namespace ChronoQuest.Endpoints.Questions.Dto;

internal sealed record QuizDto(IEnumerable<QuestionPreviewDto> Questions);