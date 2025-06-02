namespace ChronoQuest.Core.Application.Questions;

public interface IQuestionService
{
    Task GetQuestionAsync(QuestionRequest request, CancellationToken token);
    Task AnswerQuestionAsync(QuestionRequest request, CancellationToken token);
}