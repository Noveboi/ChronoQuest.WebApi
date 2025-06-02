namespace ChronoQuest.Core.Application.Tracking;

public sealed record TimeTrackingInformation(
    Guid EntityId,
    DateTimeOffset TrackingStartUtc, 
    DateTimeOffset TrackingEndUtc)
{
    public TimeSpan Duration => TrackingEndUtc - TrackingStartUtc;
}