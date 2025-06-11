using ChronoQuest.Endpoints.Questions.Dto;

namespace ChronoQuest.Endpoints.Exam.Dto;

internal sealed record ExamDto(Guid Id, IEnumerable<QuestionPreviewDto> Questions, TimeSpan TimeLimit);