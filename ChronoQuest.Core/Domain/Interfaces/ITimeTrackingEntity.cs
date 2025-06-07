using ChronoQuest.Core.Application.Tracking;

namespace ChronoQuest.Core.Domain.Interfaces;

/// <summary>
/// Describes entities which can be constructed from <see cref="TimeTrackingInformation"/> for statistical use.
/// </summary>
public interface ITimeTrackingEntity<T>
{
    static abstract T FromData(TimeTrackingInformation info, Guid userId);
}