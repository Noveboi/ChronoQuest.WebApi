using ChronoQuest.Core.Application.Chapters;
using ChronoQuest.Endpoints.Chapters.Dto;
using ChronoQuest.Endpoints.Chapters.Groups;
using ChronoQuest.Endpoints.Utilities;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters;

internal sealed class GetChapterStatsEndpoint(ChapterStatsService service) 
    : Endpoint<GetRequest, IEnumerable<ChapterStatsDto>>
{
    public override void Configure()
    {
        Get("stats");
        Group<ChapterGroup>();
    }

    public override async Task HandleAsync(GetRequest req, CancellationToken ct)
    {
        var stats = await service.GetChapterStatsAsync(req.UserId, ct);

        var dto = stats.Select(x => new ChapterStatsDto(
            Chapter: new SlimChapterDto(x.Chapter.Id, x.Chapter.Title, x.Chapter.Topic.ToString()),
            ReadingTimePerDay: x.Readings.Select(r => new ReadingTimePerDayDto(r.Date, r.Duration.TotalSeconds)),
            TotalReadingTime: x.TotalDuration.TotalSeconds));
        
        await SendAsync(dto, cancellation: ct);
    }
}