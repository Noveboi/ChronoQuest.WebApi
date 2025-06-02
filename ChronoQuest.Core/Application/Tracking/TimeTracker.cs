using ChronoQuest.Core.Application.Tracking.Store;
using Serilog;

namespace ChronoQuest.Core.Application.Tracking;

public sealed class TimeTracker(
    ITrackingStore<TrackingKey, DateTimeOffset> store,
    TimeProvider timeProvider) 
{
    public ValueTask TrackAsync(Guid userId, Guid entityId, CancellationToken token)
    {
        var key = new TrackingKey(EntityId: entityId, UserId: userId);
        var value = timeProvider.GetUtcNow();
        
        TrackingLog.Write("Start", value);
        
        return store.AddAsync(key, value, token);
    }

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
        
        await store.RemoveAsync(key, token);

        var trackingInfo = new TimeTrackingInformation(TrackingStartUtc: startTime, TrackingEndUtc: stopTime);
        Log.Information("Read chapter for {seconds} seconds", trackingInfo.ElapsedTime.TotalSeconds);

        return trackingInfo;
    }
    
    private static class TrackingLog
    {
        public static void Write(string verb, DateTimeOffset time) =>
            Log.Information("{verb} tracking at {utcTime}", verb, time);

        public static void NotFound(TrackingKey key) => 
            Log.Warning("Tracking {@key} not found.", key);
    }
}