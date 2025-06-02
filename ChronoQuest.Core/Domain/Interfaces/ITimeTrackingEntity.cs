using ChronoQuest.Core.Application.Tracking;

namespace ChronoQuest.Core.Domain.Interfaces;

public interface ITimeTrackingEntity<T>
{
    static abstract T FromData(TimeTrackingInformation info, Guid userId);
}