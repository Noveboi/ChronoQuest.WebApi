using ChronoQuest.Core.Application.Progress;
using ChronoQuest.Endpoints.Utilities;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Progress;

internal sealed record ChapterProgressDto(string Status);

internal sealed class ChapterProgressEndpoint(IProgressQueries progress) : Endpoint<GetRequest, ChapterProgressDto>  
{
    public override void Configure()
    {
        Get("chapters");
        Group<ProgressGroup>();
    }

    public override async Task HandleAsync(GetRequest req, CancellationToken ct)
    {
        var result = await progress.HasCompletedAllChapters(req.UserId, ct);

        await SendAsync(new ChapterProgressDto(result.IsSuccess
            ? "completed"
            : "ongoing"), cancellation: ct);
    }
}