using System.Security.Claims;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters.Dto;

internal sealed record GetChapterRequest(
    [property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId,
    [property: RouteParam] Guid ChapterId);