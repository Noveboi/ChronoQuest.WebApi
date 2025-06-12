using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Endpoints.Questions.Dto;
using ChronoQuest.Endpoints.Utilities;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Questions;

internal sealed class GetQuestionStatsEndpoint(QuestionStatsService service) : Endpoint<GetRequest, IEnumerable<QuestionStatsForTopicDto>>
{
    public override void Configure()
    {
        Get("questions/stats");
    }

    public override async Task HandleAsync(GetRequest req, CancellationToken ct)
    {
        var stats = await service.GetAsync(req.UserId, ct);

        var statsForTopicDto = stats.Select(s => new QuestionStatsForTopicDto(
            Topic: s.Topic.ToDto(),
            CorrectAnswersPercentage: s.CorrectAnswersPercentage,
            AverageAnswerTimeInSeconds: s.AverageAnswerTime.TotalSeconds
        ));
        
        await SendAsync(statsForTopicDto, cancellation: ct);
    }
}