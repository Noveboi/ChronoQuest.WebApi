using System.Security.Claims;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Utilities;

public sealed record GetRequest([property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId);