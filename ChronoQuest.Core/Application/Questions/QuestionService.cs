using Ardalis.Result;
using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Stats;
using ChronoQuest.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ChronoQuest.Core.Application.Questions;

internal sealed class QuestionService(ChronoQuestContext context, ITimeTracker<QuestionReadingTime> tracker) 
    : IQuestionService
{
    private readonly ILogger _log = Log.ForContext<QuestionService>();

    public async Task<List<QuestionResponse>> GetQuestionsForChapter(QuestionsForChapterRequest request, CancellationToken token)
    {
        var questions = await context.Questions
            .ForChapter(request.ChapterId)
            .WithAnswersOf(request.UserId)
            .ToListAsync(cancellationToken: token);

        return questions.Select(question => new QuestionResponse(question)).ToList();
    }

    public async Task<QuestionResponse?> GetQuestionAsync(QuestionRequest request, CancellationToken token)
    {
        var userQuestion = await context.Questions
            .WithAnswersOf(request.UserId)
            .FirstOrDefaultAsync(x => x.Id == request.QuestionId, token);
            
        if (userQuestion is null)
        {
            return null;
        }

        await tracker.TrackAsync(userId: request.UserId, entityId: request.QuestionId, token);
        return new QuestionResponse(userQuestion);
    }

    public async Task<Result<QuestionAnswer>> AnswerQuestionAsync(AnswerQuestionRequest request, CancellationToken token)
    {
        if (await tracker.StopTrackingAsync(request.UserId, request.QuestionId, token) is null)
        {
            _log.Error("Cannot answered untracked question {questId} for {userId}", request.QuestionId, request.UserId);
            return Result.Invalid(new ValidationError("Cannot answer question that you haven't selected."));
        }

        if (await GetQuestion(request.QuestionId, token) is not { } question)
        {
            _log.Error("Question with ID '{id}' not found.", request.QuestionId);
            return Result.NotFound($"Question with ID {request.QuestionId} not found.");
        }
        
        var answerResult = question.Answer(
            userId: request.UserId,
            optionId: request.ChosenOptionId);

        if (!answerResult.IsSuccess)
        {
            return answerResult.Map();
        }
        
        // TODO: Use AdaptiveLearning module to update user score.

        return answerResult.Value;
    }

    private Task<Question?> GetQuestion(Guid id, CancellationToken token)
    {
        return context.Questions.FirstOrDefaultAsync(x => x.Id == id, token);
    }
}