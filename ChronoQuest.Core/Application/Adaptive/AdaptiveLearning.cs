using System.Threading.Channels;
using ChronoQuest.Core.Domain.AdaptiveLearning;
using ChronoQuest.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChronoQuest.Core.Application.Adaptive;

internal sealed class AdaptiveLearning(IServiceProvider serviceProvider) : IAdaptiveLearning
{
    public async Task UpdateKnowledgeAsync(UpdateLearningModelRequest request, CancellationToken token)
    {
        var channel = serviceProvider.GetRequiredService<Channel<UpdateLearningModelRequest>>();
        if (!channel.Writer.TryWrite(request))
        {
            await channel.Writer.WriteAsync(request, token);
        }
    }

    public async Task<IEnumerable<MasteryHistory>> GetMasteryOverTimeAsync(Guid userId, CancellationToken token)
    {
        var context = serviceProvider.GetRequiredService<ChronoQuestContext>();
        var models = await context
            .Set<BayesianKnowledgeTracingModel>()
            .Join(context.Topics, bkt => bkt.TopicId, t => t.Id, (bkt, topic) => new
            {
                Model = bkt,
                Topic = topic
            })
            .Where(x => x.Model.UserId == userId)
            .ToListAsync(token);

        return models.Select(x => new MasteryHistory(x.Topic, x.Model.MasteryHistory));
    }
}