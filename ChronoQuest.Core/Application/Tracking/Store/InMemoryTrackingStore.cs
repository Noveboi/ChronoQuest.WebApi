
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using Serilog;

namespace ChronoQuest.Core.Application.Tracking.Store;

internal sealed class InMemoryTrackingStore<TValue> : ITrackingStore<TValue>
{
    private static readonly ConcurrentDictionary<TrackingKey, TValue> BackingStore = [];

    public ValueTask AddAsync(TrackingKey key, TValue value, CancellationToken token)
    {
        BackingStore.TryAdd(key, value);
        return ValueTask.CompletedTask;
    }

    public async IAsyncEnumerable<TValue> GetAllForUserAsync(
        Type entityType, 
        Guid userId, 
        [EnumeratorCancellation] CancellationToken token)
    {
        var keys = BackingStore.Keys
            .Where(x => x.UserId == userId && x.EntityType == entityType)
            .ToList();
        
        Log.Information("Found {count} tracking keys for {type}", keys.Count, entityType);
        
        foreach (var value in keys.Select(key => BackingStore[key]))
        {
            yield return value;
        }

        await RemoveRangeAsync(keys, token);
    }

    public async ValueTask<TValue?> GetOrDefaultAsync(TrackingKey key, CancellationToken token)
    {
        if (BackingStore.TryGetValue(key, out var value))
        {
            await RemoveAsync(key, token);
        }
        
        return value;
    }

    private ValueTask RemoveRangeAsync(IEnumerable<TrackingKey> keys, CancellationToken token)
    {
        foreach (var key in keys)
        {
            BackingStore.Remove(key, out _);
        }
        
        return ValueTask.CompletedTask;
    }
    
    private ValueTask RemoveAsync(TrackingKey key, CancellationToken token)
    {
        BackingStore.Remove(key, out _);
        return ValueTask.CompletedTask;
    }
}