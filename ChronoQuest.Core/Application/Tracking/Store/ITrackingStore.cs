namespace ChronoQuest.Core.Application.Tracking.Store;

public interface ITrackingStore<TValue>
{
    IAsyncEnumerable<TValue> GetAllForUserAsync(Guid userId, CancellationToken token);
    ValueTask<TValue?> GetOrDefaultAsync(TrackingKey key, CancellationToken token);
    ValueTask AddAsync(TrackingKey key, TValue value, CancellationToken token);
}