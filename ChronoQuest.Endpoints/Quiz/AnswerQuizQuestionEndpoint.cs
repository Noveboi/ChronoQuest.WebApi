using System.Security.Claims;
using FastEndpoints;
using Microsoft.Extensions.Logging;

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

internal sealed class AnswerQuizQuestionEndpoint : Endpoint<AnswerQuizQuestionRequest, AnswerQuizQuestionResponse>
{
    public override void Configure()
    {
        Post("answer/{chosenOptionId:guid}");
        Description(x => x.Accepts<AnswerQuizQuestionRequest>());
        Group<QuestionGroup>();
    }

    public override async Task HandleAsync(AnswerQuizQuestionRequest req, CancellationToken ct)
    {
        // IMPORTANT: Use IQuestionService!;
        
        Logger.LogInformation("User {userId} answered question {questionId} with {optionId}", req.UserId, req.QuestionId, req.ChosenOptionId);
        await SendAsync(new AnswerQuizQuestionResponse(true), cancellation: ct);
    }
}