using ChronoQuest.Core.Application.Chapters;
using ChronoQuest.Endpoints.Chapters.Dto;
using ChronoQuest.Endpoints.Chapters.Groups;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters;


internal sealed class GetChapterStatsEndpoint(ChapterStatsService service) : Endpoint<GetRequest, ChapterStatsDto>
{
    public override void Configure()
    {
        Get("stats");
        Group<ChapterGroup>();
    }

    public override async Task HandleAsync(GetRequest req, CancellationToken ct)
    {
        var stats = await service.GetChapterStatsAsync(req.UserId, ct);
        await SendAsync(stats.ToDto(), cancellation: ct);
    }
}