using ChronoQuest.Core.Application.Adaptive;
using ChronoQuest.Endpoints.AdaptiveLearning.Dto;
using ChronoQuest.Endpoints.Questions.Dto;
using ChronoQuest.Endpoints.Utilities;
using FastEndpoints;

namespace ChronoQuest.Endpoints.AdaptiveLearning;

internal sealed class GetUserPerformanceEndpoint(IAdaptiveLearning adaptiveLearning) 
    : Endpoint<GetRequest, IEnumerable<UserPerformanceForTopicDto>>
{
    public override void Configure()
    {
        Get("/performance");
    }

    public override async Task HandleAsync(GetRequest req, CancellationToken ct)
    {
        var performances = await adaptiveLearning.GetPerformanceAsync(req.UserId, ct);
        
        await SendAsync(performances.Select(x => new UserPerformanceForTopicDto(
            Score: double.Round(x.Performance.TotalScore, 3),
            State: x.Performance.LearningProgress.State.ToString(),
            Topic: x.Topic.ToDto())), cancellation: ct);
    }
}