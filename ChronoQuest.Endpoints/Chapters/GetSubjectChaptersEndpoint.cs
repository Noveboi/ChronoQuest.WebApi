using ChronoQuest.Endpoints.Chapters.Dto;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters;

internal sealed class GetSubjectChaptersEndpoint : EndpointWithoutRequest<IEnumerable<ChapterDto>> 
{
    public override void Configure() => Get("/chapters");

    public override async Task HandleAsync(CancellationToken ct)
    {
        var examples = new List<ChapterDto>
        {
            new(Id: Guid.NewGuid(), Title: "Introduction", Content: "Blah blah blah..."),
            new(Id: Guid.NewGuid(), Title: "More Stuff", Content: "Lorem ipsum and stuff...")
        };

        await SendAsync(examples, cancellation: ct);
    }
}