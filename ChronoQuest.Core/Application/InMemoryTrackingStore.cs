
using System.Collections.Concurrent;

namespace ChronoQuest.Core.Application;

internal sealed class InMemoryTrackingStore<TKey, TValue> : ITrackingStore<TKey, TValue> where TKey : notnull
{
    private static readonly ConcurrentDictionary<TKey, TValue> BackingStore = [];

    public ValueTask AddAsync(TKey key, TValue value, CancellationToken token)
    {
        BackingStore.TryAdd(key, value);
        return ValueTask.CompletedTask;
    }

    public ValueTask<TValue?> GetOrDefaultAsync(TKey key, CancellationToken token) =>
        ValueTask.FromResult(BackingStore.GetValueOrDefault(key));

    public ValueTask RemoveAsync(TKey key, CancellationToken token)
    {
        BackingStore.Remove(key, out _);
        return ValueTask.CompletedTask;
    }
}