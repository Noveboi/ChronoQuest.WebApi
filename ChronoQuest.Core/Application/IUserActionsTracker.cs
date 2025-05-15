namespace ChronoQuest.Core.Application;

public interface IUserActionTracker<T>
{
    ValueTask StartTrackingAsync(Guid userId, Guid entityId, CancellationToken token);
    ValueTask<T?> StopTrackingAsync(Guid userId, Guid entityId, CancellationToken token);
}
