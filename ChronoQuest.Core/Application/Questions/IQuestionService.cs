using Ardalis.Result;
using ChronoQuest.Core.Domain.Stats;

namespace ChronoQuest.Core.Application.Questions;

public interface IQuestionService
{
    Task<List<QuestionResponse>> GetQuestionsForChapterAsync(QuestionsForChapterRequest request, CancellationToken token);
    Task<QuestionResponse?> GetQuestionAsync(QuestionRequest request, CancellationToken token);
    Task<Result<QuestionResponse>> AnswerQuestionAsync(AnswerQuestionRequest request, CancellationToken token);
}