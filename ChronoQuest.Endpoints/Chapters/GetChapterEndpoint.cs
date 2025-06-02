using ChronoQuest.Core.Application;
using ChronoQuest.Core.Application.Chapters;
using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints.Chapters.Dto;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Endpoints.Chapters;

internal sealed class GetChapterEndpoint(IUserActionTracker<ChapterTrackingInformation> tracker, ChronoQuestContext context) 
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
        
        await tracker.StartTrackingAsync(userId: req.UserId, entityId: req.ChapterId, ct);
        await SendAsync(chapter.ToDto(), cancellation: ct);
    }
}