using Ardalis.Result;
using ChronoQuest.Core.Application.Adaptive;
using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Stats;
using ChronoQuest.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ChronoQuest.Core.Application.Questions;

internal sealed class QuestionService(
    ChronoQuestContext context, 
    ITimeTracker<QuestionReadingTime> tracker,
    IAdaptiveLearning adaptiveLearning) 
    : IQuestionService
{
    private readonly ILogger _log = Log.ForContext<QuestionService>();

    public async Task<List<Question>> GetQuestionsForChapterAsync(QuestionsForChapterRequest request, CancellationToken token)
    {
        var questions = await QueryQuestions(request.UserId)
            .AsNoTracking()
            .ForChapter(request.ChapterId)
            .OrderBy(x => x.Number)
            .ToListAsync(cancellationToken: token);

        return questions;
    }

    public async Task<Question?> GetQuestionAsync(QuestionRequest request, CancellationToken token)
    {
        var userQuestion = await QueryQuestions(request.UserId)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.QuestionId, token);
            
        if (userQuestion is null)
        {
            return null;
        }

        await tracker.TrackAsync(userId: request.UserId, entityId: request.QuestionId, token);
        return userQuestion;
    }

    public async Task<Result<Question>> AnswerQuestionAsync(
        AnswerQuestionRequest request,
        CancellationToken token)
    {
        if (await tracker.StopTrackingAsync(request.UserId, request.QuestionId, token) is null)
        {
            _log.Error("Cannot answered untracked question {questId} for {userId}", request.QuestionId, request.UserId);
            return Result.Invalid(new ValidationError("Cannot answer question that you haven't selected."));
        }

        var question = await QueryQuestions(request.UserId)
            .FirstOrDefaultAsync(x => x.Id == request.QuestionId, token);
        
        if (question is null)
        {
            _log.Error("Question with ID '{id}' not found.", request.QuestionId);
            return Result.NotFound($"Question with ID {request.QuestionId} not found.");
        }
        
        var answerResult = question.Answer(
            userId: request.UserId,
            optionId: request.ChosenOptionId);

        if (!answerResult.IsSuccess || answerResult.Value is not { } answer)
        {
            _log.Warning("Failed: {@result}", answerResult);
            return answerResult.Map();
        }
        
        _log.Information("User answered {answerState}", answer.IsCorrect ? "Correctly" : "Wrongly");
        
        await adaptiveLearning.UpdateKnowledgeAsync(
            new UpdateLearningModelRequest(
                UserId: request.UserId,
                TopicId: question.Topic.Id,
                IsPositive: answer.IsCorrect), 
            token);
        
        await context.SaveChangesAsync(token);
        
        return question;
    }

    public IQueryable<Question> QueryQuestions(Guid userId) => context.Questions
        .WithOptions()
        .WithTopic()
        .WithAnswersOf(userId)
        .AsSplitQuery();
}