using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints.Chapters.Dto;
using ChronoQuest.Endpoints.Chapters.Groups;
using ChronoQuest.Endpoints.Questions.Dto;
using ChronoQuest.Endpoints.Utilities;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Endpoints.Chapters;

internal sealed class GetChaptersEndpoint(ChronoQuestContext context) 
    : Endpoint<GetRequest, IEnumerable<ChapterPreviewDto>>
{
    public override void Configure()
    {
        Get("");
        Group<ChapterGroup>();
    }

    public override async Task HandleAsync(GetRequest req, CancellationToken ct)
    {
        var chapters = await context.Chapters
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Questions)
            .WithAnswersOf(req.UserId)
            .OrderBy(x => x.Order)
            .Select(x => new
            {
                x.Id, 
                x.Title, 
                x.Topic, 
                x.Order, 
                x.Questions,
                TotalReading = x.Readings.Where(r => r.UserId == req.UserId).Sum(r => r.TotalSeconds)
            })
            .ToListAsync(cancellationToken: ct);

        await SendAsync(chapters.Select(c => new ChapterPreviewDto(
            Id: c.Id,
            Title: c.Title,
            Topic: c.Topic.Name,
            Order: c.Order,
            ReadSeconds: (int)c.TotalReading,
            Questions: c.Questions.Select(q => new ChapterPreviewQuestionDto(
                Id: q.Id,
                Status: q.Status(req.UserId).ToDto())))), cancellation: ct);
    }
}