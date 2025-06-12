using ChronoQuest.Core.Application.Adaptive;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Core.Application.Review;

public sealed class ReviewMaterialGenerator(IAdaptiveLearning adaptiveLearning, ChronoQuestContext context)
{
    public async Task<ReviewMaterial> GenerateAsync(Guid userId, CancellationToken token)
    {
        var performances = await adaptiveLearning.GetPerformanceAsync(userId, token);
        var reviewParagraphs = await context.ReviewParagraphs.ToListAsync(token);
        throw new NotImplementedException();
    }
}