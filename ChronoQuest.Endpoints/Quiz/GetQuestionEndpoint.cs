using System.Security.Claims;
using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Endpoints.Quiz.Dto;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Quiz;

internal sealed record GetQuestionRequest(
    [property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId,
    [property: RouteParam] Guid ChapterId,
    [property: RouteParam] Guid QuestionId
);

internal sealed class GetQuestionEndpoint(IQuestionService questionService) : Endpoint<GetQuestionRequest, QuestionDto> {
    public override void Configure()
    {
        Get("");
        Group<QuestionGroup>();
    }

    public override async Task HandleAsync(GetQuestionRequest req, CancellationToken ct)
    {
        var question = await questionService.GetQuestionAsync(new QuestionRequest(req.QuestionId, req.UserId), ct);
        
        if (question is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var questionDto = question.ToDto();
        
        await SendAsync(questionDto, cancellation: ct);
    }
}