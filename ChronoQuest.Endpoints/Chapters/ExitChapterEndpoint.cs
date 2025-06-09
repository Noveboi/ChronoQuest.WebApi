using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Domain.Stats;
using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints.Chapters.Dto;
using ChronoQuest.Endpoints.Chapters.Groups;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters;

internal sealed class ExitChapterEndpoint(ITimeTracker<ChapterReadingTime> tracker, ChronoQuestContext context) 
    : Endpoint<GetChapterRequest, ChapterReadingDto>
{
    public override void Configure()
    {
        Get("{chapterId:guid}/stop-reading");
        Group<ChapterGroup>();
    }

    public override async Task HandleAsync(GetChapterRequest req, CancellationToken ct)
    {
        var readingTime = await tracker.StopTrackingAsync(userId: req.UserId, entityId: req.ChapterId, ct);
        if (readingTime is null)
        {
            await SendNoContentAsync(ct);
            return;
        }
        
        await context.SaveChangesAsync(ct);
        await SendAsync(readingTime.ToDto(), cancellation: ct);
    }
}