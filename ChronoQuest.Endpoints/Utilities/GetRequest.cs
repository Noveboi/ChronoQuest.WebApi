using System.Security.Claims;
using ChronoQuest.Endpoints.Utilities.Attributes;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Utilities;

public sealed record GetRequest([property: UserId] Guid UserId);