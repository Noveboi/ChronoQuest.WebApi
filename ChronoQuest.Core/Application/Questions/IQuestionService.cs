using Ardalis.Result;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Stats;

namespace ChronoQuest.Core.Application.Questions;

public interface IQuestionService
{
    Task<Question?> GetQuestionAsync(QuestionRequest request, CancellationToken token);
    Task<Result<QuestionAnswer>> AnswerQuestionAsync(AnswerQuestionRequest request, CancellationToken token);
}