using System.Security.Claims;
using FastEndpoints;
using Microsoft.Extensions.Logging;

namespace ChronoQuest.Endpoints.Quiz;

internal sealed record AnswerQuizRequest(
    [property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId,
    [property: RouteParam] Guid ChapterId,
    [property: RouteParam] Guid QuestionId,
    [property: RouteParam] Guid ChosenOptionId
);

internal sealed record AnswerQuizResponse(
    bool IsCorrect
);

internal sealed class AnswerQuizQuestionEndpoint : Endpoint<AnswerQuizRequest, AnswerQuizResponse>
{
    public override void Configure()
    {
        Post("answer/{chosenOptionId:guid}");
        Description(x => x.Accepts<AnswerQuizRequest>());
        Group<QuestionGroup>();
    }

    public override async Task HandleAsync(AnswerQuizRequest req, CancellationToken ct)
    {
        // IMPORTANT: Use IQuestionService!;
        
        Logger.LogInformation("User {userId} answered question {questionId} with {optionId}", req.UserId, req.QuestionId, req.ChosenOptionId);
        await SendAsync(new AnswerQuizResponse(true), cancellation: ct);
    }
}