using ChronoQuest.Core.Application.Tracking.Requests;
using ChronoQuest.Core.Application.Tracking.Store;
using ChronoQuest.Core.Domain.Interfaces;
using ChronoQuest.Core.Infrastructure;
using MediatR;
using Serilog;

namespace ChronoQuest.Core.Application.Tracking;

/// <summary>
/// Default implementation of <see cref="ITimeTracker{TStats}"/>
/// </summary>
internal sealed class TimeTracker<TStats> : 
    ITimeTracker<TStats>,
    INotificationHandler<StopTrackingEverything> where TStats : class, ITimeTrackingEntity<TStats>
{
    private readonly ITrackingStore<TrackingData> _store;
    private readonly TimeProvider _timeProvider;
    private readonly ChronoQuestContext _context;
    
    private static readonly Type EntityType = typeof(TStats);

    public TimeTracker(
        ITrackingStore<TrackingData> store,
        TimeProvider timeProvider,
        ChronoQuestContext context)
    {
        _store = store;
        _timeProvider = timeProvider;
        _context = context;
    }

    
    public async Task TrackAsync(Guid userId, Guid entityId, CancellationToken token)
    {
        var key = new TrackingKey(EntityType: EntityType, UserId: userId);
        var data = new TrackingData(_timeProvider.GetUtcNow(), entityId);
        
        TrackingLog.Write("Start", data.Start);
        
        await _store.AddAsync(key, data, token);
    }

    public async Task<TStats?> StopTrackingAsync(Guid userId, Guid entityId, CancellationToken token)
    {
        var key = new TrackingKey(EntityType: EntityType, UserId: userId);
        var stopTime = _timeProvider.GetUtcNow();

        var data = await _store.GetOrDefaultAsync(key, token);
        if (data == null) 
        {
            TrackingLog.NotFound(key);
            return null;
        }

        TrackingLog.Write("Stop", stopTime);
        
        var info = new TimeTrackingInformation(EntityId: entityId, TrackingStartUtc: data.Start, TrackingEndUtc: stopTime);
        Log.Information("Tracked {type} for {seconds} seconds", EntityType.Name, info.Duration.TotalSeconds);

        var stats = TStats.FromData(info, userId);
        _context.Set<TStats>().Add(stats);

        return stats;
    }

    public Task<TStats?> GetTrackingInfoAsync(Guid userId, Guid entityId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task Handle(StopTrackingEverything req, CancellationToken ct)
    {
        Log.Information("Stop tracking every {type}.", typeof(TStats).Name);
        var stopTime = _timeProvider.GetUtcNow();
        Log.Information("Stop tracking everything for user {userId}", req.UserId);

        var infoList = new List<TimeTrackingInformation>();
        await foreach (var data in _store.GetAllForUserAsync(EntityType, req.UserId, ct))
        {
            var trackingInfo = new TimeTrackingInformation(
                EntityId: data.EntityId, 
                TrackingStartUtc: data.Start, 
                TrackingEndUtc: stopTime);
            
            infoList.Add(trackingInfo);
        }

        _context.Set<TStats>().AddRange(infoList.Select(info => TStats.FromData(info, req.UserId)));
    }
    
    private static class TrackingLog
    {
        public static void Write(string verb, DateTimeOffset data) =>
            Log.Information("{verb} tracking {type} ({date})", verb, EntityType.Name, data);

        public static void NotFound(TrackingKey key) => 
            Log.Warning("Tracking {@key} not found.", key);
    }
}