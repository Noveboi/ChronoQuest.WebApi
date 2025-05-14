using System.Security.Claims;
using ChronoQuest.Endpoints.Quiz.Dto;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Quiz;

internal sealed record GetQuestionRequest(
    [property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId,
    [property: RouteParam] Guid ChapterId,
    [property: RouteParam] Guid QuestionId
);

internal sealed class GetQuestionEndpoint : Endpoint<GetQuestionRequest, QuestionDto> {
    public override void Configure()
    {
        Get("");
        Group<QuestionGroup>();
    }

    public override Task HandleAsync(GetQuestionRequest req, CancellationToken ct)
    {
        return base.HandleAsync(req, ct);
    }
}