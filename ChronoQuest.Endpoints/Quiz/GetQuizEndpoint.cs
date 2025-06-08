using System.Security.Claims;
using ChronoQuest.Endpoints.Quiz.Dto;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Quiz;

internal sealed record GetQuizRequest(
    [property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId,
    [property: RouteParam] Guid ChapterId
);

internal sealed class GetQuizEndpoint : Endpoint<GetQuizRequest, QuizDto>
{
    public override void Configure()
    {
        Get("");
        Group<QuizGroup>();
    }

    public override async Task HandleAsync(GetQuizRequest req, CancellationToken ct)
    {
        await SendOkAsync(ct);
    }
    
    // Να επιστρέφει question preview dto
}