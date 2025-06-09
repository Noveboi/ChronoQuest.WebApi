using ChronoQuest.Core;
using ChronoQuest.Core.Application;
using ChronoQuest.Core.Application.Markers;
using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Domain.Stats;
using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Core.Infrastructure.Workers;
using ChronoQuest.Endpoints.Chapters.Dto;
using ChronoQuest.Endpoints.Chapters.Groups;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Endpoints.Chapters;

internal sealed class GetChapterEndpoint(
    IMarkerService marker,
    ITimeTracker<ChapterReadingTime> tracker, ChronoQuestContext context) 
    : Endpoint<GetChapterRequest, ChapterDto>
{
    public override void Configure()
    {
        Get("{chapterId:guid}");
        Group<ChapterGroup>();
    }

    public override async Task HandleAsync(GetChapterRequest req, CancellationToken ct)
    {
        var chapter = await context.Chapters
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == req.ChapterId, cancellationToken: ct);

        if (chapter is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var markerRequest = new UpdateUserMarkerRequest(
            UserId: req.UserId,
            EntityId: req.ChapterId,
            Action: UserIs.ReadingChapter);

        await Task.WhenAll(
            marker.UpsertAsync(markerRequest, ct),
            tracker.TrackAsync(userId: req.UserId, entityId: req.ChapterId, ct));
        
        await SendAsync(chapter.ToDto(), cancellation: ct);
    }
}