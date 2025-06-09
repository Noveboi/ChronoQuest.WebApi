using System.Security.Claims;
using ChronoQuest.Core.Application.Markers;
using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Endpoints.Questions.Dto;
using ChronoQuest.Endpoints.Questions.Groups;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Questions;

internal sealed record GetQuestionRequest(
    [property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId,
    [property: RouteParam] Guid QuestionId
);

internal sealed class GetQuestionEndpoint(IQuestionService questionService, IMarkerService marker) 
    : Endpoint<GetQuestionRequest, QuestionDto> {
    public override void Configure()
    {
        Get("");
        Group<QuestionGroup>();
    }

    public override async Task HandleAsync(GetQuestionRequest req, CancellationToken ct)
    {
        var request = new QuestionRequest(req.QuestionId, req.UserId);
        
        if (await questionService.GetQuestionAsync(request, ct) is not { } question)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var markerRequest = new UpdateUserMarkerRequest(
            UserId: req.UserId,
            EntityId: req.QuestionId,
            Action: UserIs.AnsweringQuestion);

        await marker.UpsertAsync(markerRequest, ct);
        await SendAsync(question.ToDto(), cancellation: ct);
    }
}