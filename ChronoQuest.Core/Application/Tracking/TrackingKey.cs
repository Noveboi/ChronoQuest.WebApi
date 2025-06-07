namespace ChronoQuest.Core.Application.Tracking;

internal sealed record TrackingKey(Type EntityType, Guid UserId);