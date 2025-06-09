using System.Security.Claims;
using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Core.Infrastructure;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Endpoints.Quiz;

internal sealed record AnswerQuizQuestionRequest(
    [property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId,
    [property: RouteParam] Guid ChapterId,
    [property: RouteParam] Guid QuestionId,
    [property: RouteParam] Guid ChosenOptionId
);

internal sealed record AnswerQuizQuestionResponse(
    bool IsCorrect
);

internal sealed class AnswerQuizQuestionEndpoint(ChronoQuestContext dbContext, IQuestionService questionService) : Endpoint<AnswerQuizQuestionRequest, AnswerQuizQuestionResponse>
{
    public override void Configure()
    {
        Post("answer/{chosenOptionId:guid}");
        Description(x => x.Accepts<AnswerQuizQuestionRequest>());
        Group<QuestionGroup>();
    }

    public override async Task HandleAsync(AnswerQuizQuestionRequest req, CancellationToken ct)
    {
        var question = await dbContext
            .Questions
            .FirstOrDefaultAsync(q => q.Id == req.QuestionId, ct);
        
        if (question is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        await questionService.AnswerQuestionAsync(new AnswerQuestionRequest(req.QuestionId, req.UserId, req.ChosenOptionId), ct);
        
        if (req.ChosenOptionId == question.CorrectOptionId)
        {
            await SendAsync(new AnswerQuizQuestionResponse(true), cancellation: ct);
        }
        else
        {
            await SendAsync(new AnswerQuizQuestionResponse(false), cancellation: ct);
        }
    }
}