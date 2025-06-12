using ChronoQuest.Core.Application.Adaptive;
using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Application.Review;

public sealed class ReviewMaterialGenerator(IAdaptiveLearning adaptiveLearning)
{
    public async Task<ReviewMaterial> GenerateAsync(Guid userId, CancellationToken token)
    {
        var performance = await adaptiveLearning.GetPerformanceAsync(userId, token);
    }
}