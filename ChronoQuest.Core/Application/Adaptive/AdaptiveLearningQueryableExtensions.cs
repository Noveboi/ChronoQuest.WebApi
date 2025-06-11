using ChronoQuest.Core.Domain.AdaptiveLearning;
using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Core.Application.Adaptive;

internal static class AdaptiveLearningQueryableExtensions
{
    public static IQueryable<BayesianKnowledgeTracingModel> ForUser(
        this IQueryable<BayesianKnowledgeTracingModel> source,
        Guid userId)
    {
        return source
            .Include(x => x.Topic)
            .Where(x => x.UserId == userId);
    }
}