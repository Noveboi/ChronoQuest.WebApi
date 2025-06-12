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

    public async Task<IReadOnlyList<UserPerformanceForTopic>> GetPerformanceAsync(Guid userId, CancellationToken token)
    {
        var context = serviceProvider.GetRequiredService<ChronoQuestContext>();
        var topicGroups = await context.Questions.WithAnswersOf(userId)
            .AsSplitQuery()
            .GroupJoin(
                inner: context.Set<BayesianKnowledgeTracingModel>().ForUser(userId),
                outerKeySelector: q => q.Topic.Id,
                innerKeySelector: bkt => bkt.TopicId,
                resultSelector: (question, models) => new
                {
                    Models = models.DefaultIfEmpty(),
                    Question = question
                })
            .SelectMany(
                x => x.Models,
                (x, bkt) => new
                {
                    Model = bkt,
                    x.Question.Topic,
                    x.Question.Answers
                })
            .GroupBy(x => x.Topic)
            .ToDictionaryAsync(
                keySelector: group => group.Key,
                elementSelector: group => new
                {
                    Mastery = group
                        .Select(x => x.Model)
                        .Where(m => m != null)
                        .Distinct()
                        .SelectMany(m => m!.MasteryHistory)
                        .OrderBy(m => m.UtcDateTime),
                    Answers = group.SelectMany(x => x.Answers)
                },
                cancellationToken: token);

        return topicGroups
            .Select(kvp => new UserPerformanceForTopic(
                Performance: UserPerformance.Analyze(kvp.Value.Mastery, kvp.Value.Answers),
                Topic: kvp.Key))
            .ToList();
    }
}