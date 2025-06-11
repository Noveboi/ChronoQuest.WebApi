using ChronoQuest.Endpoints.Utilities.Attributes;

namespace ChronoQuest.Endpoints.Utilities;

public sealed record GetRequest([property: UserId] Guid UserId);