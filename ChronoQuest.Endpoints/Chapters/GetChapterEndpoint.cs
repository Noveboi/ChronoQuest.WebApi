using ChronoQuest.Core.Application;
using ChronoQuest.Core.Application.Chapters;
using ChronoQuest.Endpoints.Chapters.Dto;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters;

internal sealed class ReadChapterEndpoint(IUserActionTracker<ChapterTrackingInformation> tracker) : Endpoint<GetChapterRequest>
{
    public override void Configure()
    {
        Get("{chapterId:guid}");
        Group<ChapterGroup>();
    }

    public override async Task HandleAsync(GetChapterRequest req, CancellationToken ct)
    {
        await tracker.StartTrackingAsync(userId: req.UserId, entityId: req.ChapterId, ct);
        await SendOkAsync(ct);
    }
}