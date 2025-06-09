using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Core.Application.Questions;

internal static class QuestionQueryableExtensions
{
    public static IQueryable<Question> WithTopic(this IQueryable<Question> source) => source.Include(x => x.Topic);
    public static IQueryable<Question> WithOptions(this IQueryable<Question> source) => source.Include(x => x.Options);
    
    public static IQueryable<Question> WithAnswersOf(this IQueryable<Question> source, Guid userId)
    {
        return source.Include(x => x.Answers.Where(r => r.UserId == userId));
    }

    public static IQueryable<Question> ForChapter(this IQueryable<Question> source, Guid chapterId)
    {
        return source.Where(x => x.ChapterId == chapterId);
    }
}