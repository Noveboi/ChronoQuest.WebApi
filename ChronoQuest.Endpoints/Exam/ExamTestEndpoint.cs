using ChronoQuest.Core.Application.Exams;
using ChronoQuest.Endpoints.Exam.Dto;
using ChronoQuest.Endpoints.Questions.Dto;
using ChronoQuest.Endpoints.Utilities;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Exam;

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
            response: new ExamDto(exam.Id, exam.Questions.Select(x => x.ToPreviewDto()), exam.TimeLimit), 
            cancellation: ct);
    }
}