namespace ChronoQuest.Core.Application.Tracking.Store;

public interface ITrackingStore<in TKey, TValue> where TKey : notnull
{
    ValueTask<TValue?> GetOrDefaultAsync(TKey key, CancellationToken token);
    ValueTask RemoveAsync(TKey key, CancellationToken token);    
    ValueTask AddAsync(TKey key, TValue value, CancellationToken token);
}