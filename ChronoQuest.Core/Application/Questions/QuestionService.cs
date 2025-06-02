using ChronoQuest.Core.Infrastructure;

namespace ChronoQuest.Core.Application.Questions;

internal class QuestionService(ChronoQuestContext context) : IQuestionService
{
    public Task GetQuestionAsync(QuestionRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task AnswerQuestionAsync(QuestionRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}