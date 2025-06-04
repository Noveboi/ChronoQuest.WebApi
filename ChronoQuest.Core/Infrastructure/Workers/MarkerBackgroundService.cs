using System.Threading.Channels;
using ChronoQuest.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ChronoQuest.Core.Infrastructure.Workers;

public enum UserIs
{
    ReadingChapter,
    AnsweringQuestion,
    TakingExam
}

public sealed record UpdateUserMarkerRequest(Guid UserId, Guid EntityId, UserIs Action);

/// <summary>
/// Persists the user marker to the database in the background. This is done on a separate thread to avoid blocking
/// requests.
/// </summary>
internal sealed class MarkerBackgroundService(
    Channel<UpdateUserMarkerRequest> queue,
    IServiceProvider serviceProvider,
    ILogger<MarkerBackgroundService> logger) : BackgroundService
{
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var request in queue.Reader.ReadAllAsync(stoppingToken))
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ChronoQuestContext>();

            var marker = await context.Markers.FirstOrDefaultAsync(x => x.UserId == request.UserId, stoppingToken);
            if (marker is null)
            {
                context.Markers.Add(new UserMarker(request.UserId));
            }
            else
            {
                marker.Update(request);
            }

            await context.SaveChangesAsync(stoppingToken);
            logger.LogInformation("Save {type}. {userId} is {action}", 
                nameof(UserMarker), request.UserId, request.Action.ToString());
        }
    }
}