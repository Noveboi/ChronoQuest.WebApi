using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Domain.Interfaces;

namespace ChronoQuest.Endpoints.Exam;

public sealed record ExamTimer(TimeSpan ElapsedTime) : ITimeTrackingEntity<ExamTimer>
{
    public static ExamTimer FromData(TimeTrackingInformation info, Guid userId)
    {
        return new ExamTimer(info.Duration);
    }
}