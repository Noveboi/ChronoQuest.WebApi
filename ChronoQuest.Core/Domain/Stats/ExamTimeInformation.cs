using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Domain.Interfaces;

namespace ChronoQuest.Core.Domain.Stats;

public sealed record ExamTimeInformation(TimeSpan ElapsedTime) : ITimeTrackingEntity<ExamTimeInformation>
{
    public static ExamTimeInformation FromData(TimeTrackingInformation info, Guid userId)
    {
        return new ExamTimeInformation(info.Duration);
    }
}