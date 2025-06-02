namespace ChronoQuest.Core.Application.Tracking;

public sealed record TimeTrackingInformation(DateTimeOffset TrackingStartUtc, DateTimeOffset TrackingEndUtc)
{
    public TimeSpan ElapsedTime => TrackingEndUtc - TrackingStartUtc;
}