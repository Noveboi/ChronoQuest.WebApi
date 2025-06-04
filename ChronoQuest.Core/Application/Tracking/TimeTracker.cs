using ChronoQuest.Core.Application.Tracking.Store;
using Serilog;

namespace ChronoQuest.Core.Application.Tracking;

internal sealed record TrackingData(DateTimeOffset Start, Guid EntityId);

internal sealed class TimeTracker<T>(
    ITrackingStore<TrackingData> store,
    TimeProvider timeProvider)
{
    private static readonly Type EntityType = typeof(T);
    
    /// <summary>
    /// Mark the current time for the given user and entity.
    /// </summary>
    /// <returns></returns>
    public async Task TrackAsync(Guid userId, Guid entityId, CancellationToken token)
    {
        var key = new TrackingKey(EntityType: EntityType, EntityId: entityId, UserId: userId);
        var data = new TrackingData(timeProvider.GetUtcNow(), entityId);
        
        TrackingLog.Write("Start", data.Start);
        
        await store.AddAsync(key, data, token);
    }

    /// <summary>
    /// Mark the curren time for the given user and entity and return the elapsed time from when tracking began. 
    /// </summary>
    public async Task<TimeTrackingInformation?> StopTrackingAsync(Guid userId, Guid entityId, CancellationToken token)
    {
        var key = new TrackingKey(EntityType: EntityType, EntityId: entityId, UserId: userId);
        var stopTime = timeProvider.GetUtcNow();

        var data = await store.GetOrDefaultAsync(key, token);
        if (data == null) 
        {
            TrackingLog.NotFound(key);
            return null;
        }

        TrackingLog.Write("Stop", stopTime);
        
        var trackingInfo = new TimeTrackingInformation(EntityId: entityId, TrackingStartUtc: data.Start, TrackingEndUtc: stopTime);
        Log.Information("Read chapter for {seconds} seconds", trackingInfo.Duration.TotalSeconds);

        return trackingInfo;
    }
    
    public async Task<IReadOnlyList<TimeTrackingInformation>> StopTrackingEntirelyAsync(Guid userId, CancellationToken token)
    {
        var stopTime = timeProvider.GetUtcNow();
        Log.Information("Stop tracking everything for user {userId}", userId);

        var info = new List<TimeTrackingInformation>();
        await foreach (var data in store.GetAllForUserAsync(EntityType, userId, token))
        {
            var trackingInfo = new TimeTrackingInformation(
                EntityId: data.EntityId, 
                TrackingStartUtc: data.Start, 
                TrackingEndUtc: stopTime);
            
            info.Add(trackingInfo);
        }

        return info;
    }
    
    private static class TrackingLog
    {
        public static void Write(string verb, DateTimeOffset data) =>
            Log.Information("{verb} tracking {type} ({date})", verb, EntityType.Name, data);

        public static void NotFound(TrackingKey key) => 
            Log.Warning("Tracking {@key} not found.", key);
    }
}