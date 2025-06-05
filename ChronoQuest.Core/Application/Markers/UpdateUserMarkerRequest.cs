namespace ChronoQuest.Core.Application.Markers;

public sealed record UpdateUserMarkerRequest(Guid UserId, Guid EntityId, UserIs Action);