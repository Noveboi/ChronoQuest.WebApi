using ChronoQuest.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Core.Application.Questions;

public class QuestionStatsService(ChronoQuestContext dbContext)
{
    public async Task<IEnumerable<QuestionStatsForTopic>> GetAsync(Guid userId, CancellationToken ct)
    {
        var questions = await dbContext
            .Questions
            .WithReadingTimeOf(userId)
            .WithAnswersOf(userId)
            .GroupBy(q => q.Topic)
            .ToListAsync(ct);

        var stats = questions
            .Select(group => new QuestionStatsForTopic(
                Topic: group.Key,
                CorrectAnswersPercentage: group.SelectMany(q => q.Answers).Count(qa => qa.IsCorrect) /
                (double)group.SelectMany(q => q.Answers).Count() * 100,
                AverageAnswerTime: TimeSpan.FromSeconds(group
                    .SelectMany(q => q.ReadingTime
                        .Select(qrt => qrt.Duration.TotalSeconds))
                    .Average())
            ));
        
        return stats;
    }
}