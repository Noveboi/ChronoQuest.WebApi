using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Stats;
using ChronoQuest.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Core.Application.Questions;

internal sealed class QuestionService(ChronoQuestContext context, ITimeTracker<QuestionReadingTime> tracker) 
    : IQuestionService
{
    public async Task<Question?> GetQuestionAsync(QuestionRequest request, CancellationToken token)
    {
        if (await context.Questions.FirstOrDefaultAsync(x => x.Id == request.QuestionId, token) is not { } question)
        {
            return null;
        }

        await tracker.TrackAsync(userId: request.UserId, entityId: request.QuestionId, token);
        return question;
    }

    public Task AnswerQuestionAsync(QuestionRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}