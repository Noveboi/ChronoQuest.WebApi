using ChronoQuest.Endpoints.Chapters.Dto;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters;

internal sealed class GetSubjectChaptersEndpoint : EndpointWithoutRequest<IEnumerable<ChapterPreviewDto>> 
{
    public override void Configure()
    {
        Get("");
        Group<ChapterGroup>();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var examples = new List<ChapterPreviewDto>
        {
            new(Id: Guid.NewGuid(), Title: "Introduction"),
            new(Id: Guid.NewGuid(), Title: "More Stuff")
        };

        await SendAsync(examples, cancellation: ct);
    }
}