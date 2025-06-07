using System.Threading.Channels;
using ChronoQuest.Core.Domain;
using ChronoQuest.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChronoQuest.Core.Application.Markers;

internal sealed class MarkerService(IServiceProvider serviceProvider) : IMarkerService
{
    public async Task UpsertAsync(UpdateUserMarkerRequest request, CancellationToken token)
    {
        var queue = serviceProvider.GetRequiredService<Channel<UpdateUserMarkerRequest>>();
        if (!queue.Writer.TryWrite(request))
        {
            await queue.Writer.WriteAsync(request, token);
        }
    }

    public Task<UserMarker?> GetAsync(Guid userId, CancellationToken token)
    {
        var context = serviceProvider.GetRequiredService<ChronoQuestContext>();
        return context.Markers.FirstOrDefaultAsync(x => x.UserId == userId, token);
    }
}