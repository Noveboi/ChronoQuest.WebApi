using ChronoQuest.Core.Domain.Interfaces;

namespace ChronoQuest.Core.Application.Tracking;

/// <summary>
/// Marks the time a user spent interacting with some entity.
/// </summary>
public interface ITimeTracker<TStats> where TStats : class, ITimeTrackingEntity<TStats>
{
    Task TrackAsync(Guid userId, Guid entityId, CancellationToken token);
    Task<TStats?> StopTrackingAsync(Guid userId, Guid entityId, CancellationToken token);
    Task<TStats?> GetTrackingInfoAsync(Guid userId, Guid entityId, CancellationToken token);
}