using ChronoQuest.Core.Application.Exams;
using ChronoQuest.Endpoints.Exams.Dto;
using ChronoQuest.Endpoints.Questions.Dto;
using ChronoQuest.Endpoints.Utilities;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Exams;

internal sealed class ExamTestEndpoint(ExamGenerator generator) : Endpoint<GetRequest, ExamDto>
{
    public override void Configure()
    {
        Get("/exam/test");
    }

    public override async Task HandleAsync(GetRequest req, CancellationToken ct)
    {
        var exam = await generator.GenerateAsync(req.UserId, ct);
        await SendAsync(
            response: new ExamDto(
                Id: exam.Id,
                TimeLimitInSeconds: exam.TimeLimit.TotalSeconds,
                Questions: exam.Questions.Select(x => x.ToPreviewDto())), 
            cancellation: ct);
    }
}