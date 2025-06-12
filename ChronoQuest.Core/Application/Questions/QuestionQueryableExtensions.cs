using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ChronoQuest.Core.Application.Questions;

public static class QuestionQueryableExtensions
{
    public static IQueryable<Question> WithTopic(this IQueryable<Question> source) => source.Include(x => x.Topic);
    public static IQueryable<Question> WithOptions(this IQueryable<Question> source) => source.Include(x => x.Options);
    
    public static IQueryable<Question> WithAnswersOf(this IQueryable<Question> source, Guid userId)
    {
        return source.Include(x => x.Answers.Where(r => r.UserId == userId));
    }

    public static IQueryable<Question> WithReadingTimeOf(this IQueryable<Question> source, Guid userId)
    {
        return source.Include(x => x.ReadingTime.Where(r => r.UserId == userId));
    }
    
    public static IQueryable<Chapter> WithAnswersOf(this IIncludableQueryable<Chapter, IEnumerable<Question>> source, Guid userId)
    {
        return source.ThenInclude(x => x.Answers.Where(r => r.UserId == userId));
    }
    
    public static IQueryable<Question> ForChapter(this IQueryable<Question> source, Guid chapterId)
    {
        return source.Where(x => x.ChapterId == chapterId);
    }

    public static IQueryable<Question> WithoutChapter(this IQueryable<Question> source)
    {
        return source.Where(x => x.ChapterId == null);
    }

    public static IQueryable<Question> ForTopic(this IQueryable<Question> source, Guid topicId)
    {
        return source.Where(x => x.Topic.Id == topicId);
    }

    public static IQueryable<Question> HavingDifficulty(this IQueryable<Question> source, Difficulty diff)
    {
        return source.Where(x => x.Difficulty == diff);
    }

    public static IQueryable<Question> PickRandom(this IQueryable<Question> source)
    {
        return source.OrderBy(x => EF.Functions.Random());
    }
}