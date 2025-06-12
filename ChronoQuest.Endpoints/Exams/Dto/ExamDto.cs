using ChronoQuest.Endpoints.Questions.Dto;

namespace ChronoQuest.Endpoints.Exams.Dto;

internal sealed record ExamDto(Guid Id, IEnumerable<QuestionPreviewDto> Questions, double TimeLimitInSeconds);