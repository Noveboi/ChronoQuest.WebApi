using Ardalis.Result;
using ChronoQuest.Core.Domain.Stats;

namespace ChronoQuest.Core.Application.Questions;

public interface IQuestionService
{
    Task<List<QuestionResponse>> GetQuestionsForChapter(QuestionsForChapterRequest request, CancellationToken token);
    Task<QuestionResponse?> GetQuestionAsync(QuestionRequest request, CancellationToken token);
    Task<Result<QuestionAnswer>> AnswerQuestionAsync(AnswerQuestionRequest request, CancellationToken token);
}