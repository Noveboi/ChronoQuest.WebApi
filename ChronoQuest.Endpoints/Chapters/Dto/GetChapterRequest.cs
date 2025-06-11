using System.Security.Claims;
using ChronoQuest.Endpoints.Utilities.Attributes;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters.Dto;

internal sealed record GetChapterRequest(
    [property: UserId] Guid UserId,
    [property: RouteParam] Guid ChapterId);