namespace ChronoQuest.Core.Application;

public interface IUserActionTracker<TTracked>
{
    ValueTask StartTrackingAsync(Guid userId, Guid entityId, CancellationToken token);
    ValueTask<TTracked?> StopTrackingAsync(Guid userId, Guid entityId, CancellationToken token);
}
