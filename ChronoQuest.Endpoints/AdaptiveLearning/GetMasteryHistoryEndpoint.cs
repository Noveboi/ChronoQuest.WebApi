using System.Security.Claims;
using ChronoQuest.Core.Application.Adaptive;
using ChronoQuest.Endpoints.AdaptiveLearning.Dto;
using ChronoQuest.Endpoints.Questions.Dto;
using FastEndpoints;

namespace ChronoQuest.Endpoints.AdaptiveLearning;

internal sealed record GetMasteryHistoryRequest(
    [property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId,
    [property: RouteParam] Guid TopicId);

internal sealed class GetMasteryHistoryEndpoint(IAdaptiveLearning adaptiveLearning) 
    : Endpoint<GetMasteryHistoryRequest, IEnumerable<UserMasteryHistoryDto>>
{
    public override void Configure()
    {
        Get("/mastery");
    }

    public override async Task HandleAsync(GetMasteryHistoryRequest req, CancellationToken ct)
    {
        var history = await adaptiveLearning.GetMasteryOverTimeAsync(req.UserId, ct);
        
        await SendAsync(
            response: history.Select(x => new UserMasteryHistoryDto(
                Topic: x.Topic.ToDto(),
                History: x.History.Select(y => new UserMasteryDto(
                    UtcDateTime: y.UtcDateTime,
                    MasteryLevel: y.ProbabilityOfMastery.Value)))),
            cancellation: ct);
    }
}