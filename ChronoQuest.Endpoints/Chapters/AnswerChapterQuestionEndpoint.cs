using System.Security.Claims;
using Ardalis.Result.AspNetCore;
using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Endpoints.Chapters.Groups;
using ChronoQuest.Endpoints.Questions.Dto;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters;

internal sealed record AnswerChapterQuestionRequest(
    [property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId,
    [property: RouteParam] Guid QuestionId,
    [property: RouteParam] Guid ChosenOptionId
);

internal sealed class AnswerChapterQuestionEndpoint(IQuestionService questionService) 
    : Endpoint<AnswerChapterQuestionRequest, QuestionDto>
{
    public override void Configure()
    {
        Get("answer/{chosenOptionId:guid}");
        Group<ChapterQuestionGroup>();
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