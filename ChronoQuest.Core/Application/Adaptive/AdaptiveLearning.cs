using ChronoQuest.Core.Domain.AdaptiveLearning;
using ChronoQuest.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ChronoQuest.Core.Application.Adaptive;

internal sealed class AdaptiveLearning(ChronoQuestContext context) : IAdaptiveLearning
{
    private readonly ILogger _log = Log.ForContext<AdaptiveLearning>();
    
    public async Task UpdateKnowledgeAsync(Guid userId, Guid topicId, bool isPositive)
    {
        var bkt = context.Set<BayesianKnowledgeTracingModel>();
        var model = await bkt.FirstOrDefaultAsync(x => x.UserId == userId && x.TopicId == topicId);

        if (model is null)
        {
            model = BayesianKnowledgeTracingModel.CreateWithDefaultParameters(userId, topicId);
            bkt.Add(model);
        }
        
        model.Update(isPositive);
        _log.Information("User topic mastery: {score}", model.CurrentProbabilityOfMastery);
    }
}