using ChronoQuest.Core.Domain.Interfaces;

namespace ChronoQuest.Core.Application.Tracking;

public interface ITimeTracker<TStats> where TStats : class, ITimeTrackingEntity<TStats>
{
    Task TrackAsync(Guid userId, Guid entityId, CancellationToken token);
    Task<TStats?> StopTrackingAsync(Guid userId, Guid entityId, CancellationToken token);
}