using System.Security.Claims;
using Ardalis.Result.AspNetCore;
using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Endpoints.Questions.Dto;
using ChronoQuest.Endpoints.Questions.Groups;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Questions;

internal sealed record AnswerChapterQuestionRequest(
    [property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId,
    [property: RouteParam] Guid QuestionId,
    [property: RouteParam] Guid ChosenOptionId
);

internal sealed class AnswerQuestionEndpoint(IQuestionService questionService) 
    : Endpoint<AnswerChapterQuestionRequest, QuestionDto>
{
    public override void Configure()
    {
        Get("answer/{chosenOptionId:guid}");
        Group<QuestionGroup>();
    }

    public override async Task HandleAsync(AnswerChapterQuestionRequest req, CancellationToken ct)
    {
        var request = new AnswerQuestionRequest(req.QuestionId, req.UserId, req.ChosenOptionId);
        var answerResult = await questionService.AnswerQuestionAsync(request, ct);

        if (answerResult.Value is not { } question)
        {
            await SendResultAsync(answerResult.ToMinimalApiResult());
            return;
        }

        await SendAsync(question.ToDto(), cancellation: ct);
    }
}