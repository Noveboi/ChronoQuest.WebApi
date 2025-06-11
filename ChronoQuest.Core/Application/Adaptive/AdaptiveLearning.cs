using System.Threading.Channels;
using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Core.Domain.AdaptiveLearning;
using ChronoQuest.Core.Domain.AdaptiveLearning.Metrics;
using ChronoQuest.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
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
        var models = await context.Set<BayesianKnowledgeTracingModel>()
            .ForUser(userId)
            .ToListAsync(token);

        return models.Select(x => new MasteryHistory(
            Topic: x.Topic, 
            History: x.MasteryHistory.OrderBy(m => m.UtcDateTime)));
    }

    public async Task<IEnumerable<UserPerformanceForTopic>> GetPerformanceAsync(Guid userId, CancellationToken token)
    {
        var context = serviceProvider.GetRequiredService<ChronoQuestContext>();
        var modelGroups = await context.Set<BayesianKnowledgeTracingModel>()
            .ForUser(userId)
            .Join(
                inner: context.Questions.WithAnswersOf(userId),
                outerKeySelector: bkt => bkt.TopicId,
                innerKeySelector: q => q.Topic.Id,
                resultSelector: (bkt, question) => new
                {
                    Model = bkt, 
                    question.Topic,
                    question.Answers
                })
            .GroupBy(x => x.Model)
            .ToListAsync(token);

        return modelGroups.Select(group => new UserPerformanceForTopic(
            Performance: UserPerformance.Analyze(group.Key, group.SelectMany(x => x.Answers)),
            Topic: group.Key.Topic));
    }
}