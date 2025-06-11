using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints.Chapters.Dto;
using ChronoQuest.Endpoints.Chapters.Groups;
using ChronoQuest.Endpoints.Questions.Dto;
using ChronoQuest.Endpoints.Utilities;
using FastEndpoints;
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
            .Include(x => x.Questions
                .AsQueryable()
                .WithAnswersOf(req.UserId))
            .Join(context.ChapterReadings, c => c.Id, r => r.ChapterId, (c, r) => new
            {
                Chapter = c,
                Reading = r
            })
            .GroupBy(x => x.Chapter)
            .Select(group => new
            {
                Chapter = group.Key,
                TotalReading = group.Sum(g => g.Reading.TotalSeconds)
            })
            .OrderBy(x => x.Chapter.Order)
            .Select(x => new
            {
                x.Chapter.Id, 
                x.Chapter.Title, 
                x.Chapter.Topic, 
                x.Chapter.Order, 
                x.TotalReading,
                x.Chapter.Questions
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
                Status: q.Status.ToDto())))), cancellation: ct);
    }
}