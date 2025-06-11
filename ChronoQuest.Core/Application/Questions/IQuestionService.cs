using Ardalis.Result;
using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Application.Questions;

public interface IQuestionService
{
    Task<List<Question>> GetQuestionsForChapterAsync(QuestionsForChapterRequest request, CancellationToken token);
    Task<Question?> GetQuestionAsync(QuestionRequest request, CancellationToken token);
    Task<Result<Question>> AnswerQuestionAsync(AnswerQuestionRequest request, CancellationToken token);
}