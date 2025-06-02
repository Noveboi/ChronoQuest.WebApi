using ChronoQuest.Core.Application.Tracking.Store;
using Serilog;

namespace ChronoQuest.Core.Application.Tracking;

public sealed class TimeTracker(
    ITrackingStore<DateTimeOffset> store,
    TimeProvider timeProvider) 
{
    /// <summary>
    /// Mark the current time for the given user and entity.
    /// </summary>
    /// <returns></returns>
    public ValueTask TrackAsync(Guid userId, Guid entityId, CancellationToken token)
    {
        var key = new TrackingKey(EntityId: entityId, UserId: userId);
        var value = timeProvider.GetUtcNow();
        
        TrackingLog.Write("Start", value);
        
        return store.AddAsync(key, value, token);
    }

    /// <summary>
    /// Mark the curren time for the given user and entity and return the elapsed time from when tracking began. 
    /// </summary>
    public async ValueTask<TimeTrackingInformation?> StopTrackingAsync(Guid userId, Guid entityId, CancellationToken token)
    {
        var key = new TrackingKey(EntityId: entityId, UserId: userId);
        var stopTime = timeProvider.GetUtcNow();

        var startTime = await store.GetOrDefaultAsync(key, token);
        if (startTime == default) 
        {
            TrackingLog.NotFound(key);
            return null;
        }

        TrackingLog.Write("Stop", stopTime);
        
        var trackingInfo = new TimeTrackingInformation(TrackingStartUtc: startTime, TrackingEndUtc: stopTime);
        Log.Information("Read chapter for {seconds} seconds", trackingInfo.ElapsedTime.TotalSeconds);

        return trackingInfo;
    }
    
    public async ValueTask<IReadOnlyList<TimeTrackingInformation>> StopTrackingEntirelyAsync(Guid userId, CancellationToken token)
    {
        var stopTime = timeProvider.GetUtcNow();
        Log.Information("Stop tracking everything for user {userId}", userId);

        var info = new List<TimeTrackingInformation>();
        await foreach (var startTime in store.GetAllForUserAsync(userId, token))
        {
            var trackingInfo = new TimeTrackingInformation(TrackingStartUtc: startTime, TrackingEndUtc: stopTime);
            info.Add(trackingInfo);
        }

        return info;
    }
    
    private static class TrackingLog
    {
        public static void Write(string verb, DateTimeOffset time) =>
            Log.Information("{verb} tracking at {utcTime}", verb, time);

        public static void NotFound(TrackingKey key) => 
            Log.Warning("Tracking {@key} not found.", key);
    }
}