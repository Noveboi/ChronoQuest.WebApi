using System.Text;
using ChronoQuest.Core.Application.Adaptive;
using ChronoQuest.Core.Domain.AdaptiveLearning.Metrics;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Core.Application.Review;

public sealed class ReviewMaterialGenerator(IAdaptiveLearning adaptiveLearning, ChronoQuestContext context)
{
    private const int MaxParagraphs = 6;
    
    public async Task<ReviewMaterial> GenerateAsync(Guid userId, CancellationToken token)
    {
        var performances = await adaptiveLearning.GetPerformanceAsync(userId, token);
        var reviewParagraphs = await context.ReviewParagraphs
            .OrderBy(x => x.Order)
            .GroupBy(x => x.Topic)
            .ToDictionaryAsync(
                keySelector: x => x.Key,
                elementSelector: x => x.ToList(), 
                cancellationToken: token);

        var paragraphs = performances
            .Select(performance =>
            {
                var paragraphsForTopic = reviewParagraphs[performance.Topic];
                var numberOfParagraphs = DetermineNumberOfParagraphs(performance);

                return new
                {
                    Paragraphs = paragraphsForTopic.Take(numberOfParagraphs), 
                    performance.Topic
                };
            })
            .Aggregate(new StringBuilder(), (builder, x) =>
            {
                var paragraphs = x.Paragraphs.ToList();
                if (paragraphs is [])
                    return builder;
                
                builder.AppendLine($"<h2>{x.Topic} Review</h2>");
                
                foreach (var paragraph in x.Paragraphs)
                {
                    builder.AppendLine($"<p>{paragraph.Content}</p>");
                }

                return builder;
            })
            .ToString();

        return new ReviewMaterial(userId, paragraphs);
    }

    private static int DetermineNumberOfParagraphs(UserPerformanceForTopic performance)
    {
        var learning = performance.Performance.LearningProgress;

        var confidenceScalar = learning.Confidence switch
        {
            <= 0.7 => 1,
            _ => 0
        };

        var statusScalar = learning.State switch
        {
            LearningState.Initial => MaxParagraphs,
            LearningState.Struggling => MaxParagraphs,
            LearningState.StrugglingButImproving => MaxParagraphs - 1,
            LearningState.ActiveLearning => 3,
            LearningState.Steady => 2,
            LearningState.Plateau => 3,
            LearningState.Mastering => 1,
            _ => 0
        };

        return Math.Min(MaxParagraphs, Math.Max(0, confidenceScalar + statusScalar));
    }
}