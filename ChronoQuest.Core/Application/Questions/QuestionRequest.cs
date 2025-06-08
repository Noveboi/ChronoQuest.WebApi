namespace ChronoQuest.Core.Application.Questions;

public sealed record QuestionRequest(Guid QuestionId, Guid UserId);
public sealed record AnswerQuestionRequest(Guid QuestionId, Guid UserId, Guid ChosenOptionId);