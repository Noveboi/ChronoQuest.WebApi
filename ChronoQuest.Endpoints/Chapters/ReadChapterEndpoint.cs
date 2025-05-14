using System.Security.Claims;
using FastEndpoints;
using Microsoft.Extensions.Logging;

namespace ChronoQuest.Endpoints.Chapters;

/// <summary>
/// Used for updating the user's chapter stats, specifically the time spent reading. 
/// </summary>
/// <param name="UserId">The user reading the chapter.</param>
/// <param name="ChapterId">The chapter being read.</param>
/// <param name="SecondsRead">The number of seconds the user spent reading the chapter/</param>
internal sealed record ReadChapterRequest(
    [property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId,
    [property: RouteParam] Guid ChapterId,
    int SecondsRead);

internal sealed class ReadChapterEndpoint : Endpoint<ReadChapterRequest>
{
    public override void Configure()
    {
        Post("{chapterId:guid}/read");
        Group<ChapterGroup>();
    }

    public override async Task HandleAsync(ReadChapterRequest req, CancellationToken ct)
    {
        Logger.LogInformation("User {userId} has read {chapterId} for {secs} seconds.", req.UserId, req.ChapterId, req.SecondsRead);
        await SendOkAsync(ct);
    }
}