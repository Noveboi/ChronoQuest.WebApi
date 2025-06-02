namespace ChronoQuest.Core.Application.Tracking.Store;

internal interface ITrackingStore<TValue>
{
    IAsyncEnumerable<TValue> GetAllForUserAsync(Type entityType, Guid userId, CancellationToken token);
    ValueTask<TValue?> GetOrDefaultAsync(TrackingKey key, CancellationToken token);
    ValueTask AddAsync(TrackingKey key, TValue value, CancellationToken token);
}