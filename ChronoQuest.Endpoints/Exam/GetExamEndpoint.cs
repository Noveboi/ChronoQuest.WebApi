using ChronoQuest.Core.Application.Exams;
using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints.Exam.Dto;
using ChronoQuest.Endpoints.Questions.Dto;
using ChronoQuest.Endpoints.Utilities;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChronoQuest.Endpoints.Exam;

internal sealed class GetExamEndpoint(
    ChronoQuestContext dbContext,
    ExamGenerator generator,
    ITimeTracker<ExamTimer> tracker) : Endpoint<GetRequest, ExamDto>
{
    public override void Configure()
    {
        Get("exam");
    }

    public override async Task HandleAsync(GetRequest req, CancellationToken ct)
    {
        var exam = await dbContext
            .Exams
            .Include(e => e.Questions)
            .FirstOrDefaultAsync(e => e.UserId == req.UserId, ct);

        if (exam == null)
        {
            Logger.LogInformation("Generating exam for user.");
            
            exam = await generator.GenerateAsync(req.UserId, ct);
            dbContext.Add(exam);
            await dbContext.SaveChangesAsync(ct);
        }
        
        var examDto = new ExamDto(
            Id: exam.Id,
            Questions: exam.Questions.Select(q => q.ToPreviewDto()),
            TimeLimitInSeconds: exam.TimeLimit.TotalSeconds);
        
        await tracker.TrackAsync(req.UserId, exam.Id, ct);
        
        await SendAsync(examDto, cancellation: ct);
    }
}