using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints.Chapters.Dto;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Endpoints.Chapters;

internal sealed class GetChaptersEndpoint(ChronoQuestContext context) 
    : EndpointWithoutRequest<IEnumerable<ChapterPreviewDto>>
{
    public override void Configure()
    {
        Get("");
        Group<ChapterGroup>();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var chapters = await context.Chapters
            .AsNoTracking()
            .Select(x => new { x.Id, x.Title, x.Topic })
            .ToListAsync(cancellationToken: ct);

        await SendAsync(chapters.Select(c => new ChapterPreviewDto(
            Id: c.Id,
            Title: c.Title,
            Topic: c.Topic.Name)), cancellation: ct);
    }
}