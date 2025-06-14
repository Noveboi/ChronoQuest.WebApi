using Ardalis.Result;
using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Core.Application.Progress;

public interface IProgressQueries
{
    Task<Result> HasCompletedAllChapters(Guid userId, CancellationToken token);
    Task<Result> HasCompletedReviewMaterial(Guid userId, CancellationToken token);
}

internal sealed class ProgressQueries(ChronoQuestContext context) : IProgressQueries
{
    public async Task<Result> HasCompletedAllChapters(Guid userId, CancellationToken token)
    {
        var answeredAllChapterQuestions = await context.OrderedQuestions
            .WithAnswersOf(userId)
            .Where(q => q.ChapterId != null)
            .AllAsync(q => q.Answers.Any(), token);

        return answeredAllChapterQuestions
            ? Result.Success()
            : Result.Invalid(new ValidationError("You still need to answer questions!"));
    }

    public async Task<Result> HasCompletedReviewMaterial(Guid userId, CancellationToken token)
    {
        return await context.ReviewMaterial.FirstOrDefaultAsync(x => x.UserId == userId, token) switch
        {
            null => Result.Invalid(new ValidationError("You haven't received review material yet!")),
            _ => Result.Success()
        };
    }
}