using ChronoQuest.Core.Application;
using ChronoQuest.Core.Application.Chapters;
using ChronoQuest.Endpoints.Chapters.Dto;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters;

internal sealed class ExitChapterEndpoint(IUserActionTracker<ChapterTrackingInformation> tracker) : Endpoint<GetChapterRequest>
{
    public override void Configure()
    {
        Get("{chapterId:guid}/stop-reading");
        Group<ChapterGroup>();
    }

    public override async Task HandleAsync(GetChapterRequest req, CancellationToken ct)
    {
        var info = await tracker.StopTrackingAsync(userId: req.UserId, entityId: req.ChapterId, ct);
        if (info is null) 
        {
            await SendNoContentAsync(ct);
            return;
        }

        await SendOkAsync(ct);
    }
}