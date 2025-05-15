using System.Security.Principal;
using Serilog;

namespace ChronoQuest.Core.Application;

internal sealed class ChapterReadingTracker(
    ITrackingStore<ChapterTrackingKey, DateTimeOffset> store, 
    TimeProvider timeProvider) : IUserActionTracker<ChapterTrackingInformation>
{    
    private static readonly ILogger _log = Log.ForContext<ChapterReadingTracker>();

    public ValueTask StartTrackingAsync(Guid chapterId, Guid userId, CancellationToken token)
    {
        var key = new ChapterTrackingKey(ChapterId: chapterId, UserId: userId);
        var value = timeProvider.GetUtcNow();

        TrackingLog.Write("Start", key, value);

        return store.AddAsync(key, value, token);
    }

    public async ValueTask<ChapterTrackingInformation?> StopTrackingAsync(Guid chapterId, Guid userId, CancellationToken token)
    {
        var key = new ChapterTrackingKey(ChapterId: chapterId, UserId: userId);
        var stopTime = timeProvider.GetUtcNow();

        var startTime = await store.GetOrDefaultAsync(key, token);
        if (startTime == default) 
        {
            TrackingLog.NotFound(key);
            return null;
        }

        TrackingLog.Write("Stop", key, stopTime);
        
        await store.RemoveAsync(key, token);

        var trackingInfo = new ChapterTrackingInformation(StartedReadingUtc: startTime, StoppedReadingUtc: stopTime);
        _log.Information("Read chapter for {seconds} seconds", trackingInfo.TimeSpentReading.TotalSeconds);

        return trackingInfo;
    }

    private static class TrackingLog 
    {        
        public static void Write(string verb, ChapterTrackingKey key, DateTimeOffset time) =>
            _log.Information("{verb} tracking user reading chapter {@key} starting at {utcTime}", verb, key, time);

        public static void NotFound(ChapterTrackingKey key) => 
            _log.Warning("Chapter tracking {@key} not found.", key);
    }
}
internal sealed record ChapterTrackingKey(Guid ChapterId, Guid UserId);

public sealed record ChapterTrackingInformation(
    DateTimeOffset StartedReadingUtc,
    DateTimeOffset StoppedReadingUtc) 
{
    public TimeSpan TimeSpentReading => StoppedReadingUtc - StartedReadingUtc;
}
