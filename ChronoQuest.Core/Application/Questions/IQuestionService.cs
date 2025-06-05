using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Application.Questions;

public interface IQuestionService
{
    Task<Question?> GetQuestionAsync(QuestionRequest request, CancellationToken token);
    Task AnswerQuestionAsync(QuestionRequest request, CancellationToken token);
}