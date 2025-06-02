using ChronoQuest.Core.Application.Tracking.Requests;
using ChronoQuest.Core.Domain.Interfaces;
using ChronoQuest.Core.Infrastructure;
using MediatR;
using Serilog;

namespace ChronoQuest.Core.Application.Tracking;

internal sealed class EntityTimeTracker<TStats>(TimeTracker<TStats> tracker, ChronoQuestContext context) : 
    ITimeTracker<TStats>,
    INotificationHandler<StopTrackingEverything> where TStats : class, ITimeTrackingEntity<TStats>
{
    public ValueTask TrackAsync(Guid userId, Guid chapterId, CancellationToken token)
    {
        return tracker.TrackAsync(userId, chapterId, token);
    }

    public async ValueTask<TStats?> StopTrackingAsync(Guid userId, Guid chapterId, CancellationToken token)
    {
        var info = await tracker.StopTrackingAsync(userId, chapterId, token);
        if (info is null)
        {
            return null;
        }

        var stats = TStats.FromData(info, userId);
        context.Set<TStats>().Add(stats);

        return stats;
    }

    public async Task Handle(StopTrackingEverything req, CancellationToken ct)
    {
        Log.Information("Stop tracking every {type}.", typeof(TStats).Name);
        var infoList = await tracker.StopTrackingEntirelyAsync(req.UserId, ct);
        context.Set<TStats>().AddRange(infoList.Select(info => TStats.FromData(info, req.UserId)));
    }
}