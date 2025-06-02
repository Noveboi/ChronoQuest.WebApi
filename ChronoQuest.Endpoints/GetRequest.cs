using System.Security.Claims;
using FastEndpoints;

namespace ChronoQuest.Endpoints;

public sealed record GetRequest([property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId);