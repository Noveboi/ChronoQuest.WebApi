namespace ChronoQuest.Core.Application;

public interface ITrackingStore<TKey, TValue> where TKey : notnull
{
    ValueTask<TValue?> GetOrDefaultAsync(TKey key, CancellationToken token);
    ValueTask RemoveAsync(TKey key, CancellationToken token);    
    ValueTask AddAsync(TKey key, TValue value, CancellationToken token);
}