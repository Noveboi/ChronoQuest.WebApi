using System.Threading.Channels;
using ChronoQuest.Core.Application.Adaptive;
using ChronoQuest.Core.Domain.AdaptiveLearning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ChronoQuest.Core.Infrastructure.Workers;

internal sealed class AdaptiveLearningBackgroundService(
    Channel<UpdateLearningModelRequest> channel,
    IServiceProvider serviceProvider) : BackgroundService
{
    private readonly ILogger _log = Log.ForContext<AdaptiveLearningBackgroundService>();
    
    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        await foreach (var req in channel.Reader.ReadAllAsync(ct))
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ChronoQuestContext>();
        
            var bkt = context.Set<BayesianKnowledgeTracingModel>();
            var model = await bkt.FirstOrDefaultAsync(x => x.UserId == req.UserId && x.TopicId == req.TopicId, ct);

            if (model is null)
            {
                model = BayesianKnowledgeTracingModel.CreateWithDefaultParameters(req.UserId, req.TopicId);
                bkt.Add(model);
            }
        
            model.Update(req.IsPositive);
            
            await context.SaveChangesAsync(ct);
            
            _log.Information("User topic mastery: {score}", model.CurrentProbabilityOfMastery);
        }
    }
}