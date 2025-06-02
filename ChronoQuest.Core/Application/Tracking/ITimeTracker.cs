using ChronoQuest.Core.Domain.Interfaces;

namespace ChronoQuest.Core.Application.Tracking;

public interface ITimeTracker<TStats> where TStats : class, ITimeTrackingEntity<TStats>
{
    ValueTask TrackAsync(Guid userId, Guid entityId, CancellationToken token);
    ValueTask<TStats?> StopTrackingAsync(Guid userId, Guid entityId, CancellationToken token);
}