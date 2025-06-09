using System.Security.Claims;
using Ardalis.Result.AspNetCore;
using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Endpoints.Questions.Groups;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Questions;

internal sealed record AnswerChapterQuestionRequest(
    [property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId,
    [property: RouteParam] Guid QuestionId,
    [property: RouteParam] Guid ChosenOptionId
);

internal sealed record AnswerChapterQuestionResponse(
    bool IsCorrect
);

internal sealed class AnswerChapterQuestionEndpoint(IQuestionService questionService) 
    : Endpoint<AnswerChapterQuestionRequest, AnswerChapterQuestionResponse>
{
    public override void Configure()
    {
        Post("answer/{chosenOptionId:guid}");
        Description(x => x.Accepts<AnswerChapterQuestionRequest>());
        Group<QuestionGroup>();
    }

    public override async Task HandleAsync(AnswerChapterQuestionRequest req, CancellationToken ct)
    {
        var request = new AnswerQuestionRequest(req.QuestionId, req.UserId, req.ChosenOptionId);
        var answerResult = await questionService.AnswerQuestionAsync(request, ct);

        if (answerResult.Value is not { } answer)
        {
            await SendResultAsync(answerResult.ToMinimalApiResult());
            return;
        }

        await SendAsync(new AnswerChapterQuestionResponse(answer.IsCorrect), cancellation: ct);
    }
}