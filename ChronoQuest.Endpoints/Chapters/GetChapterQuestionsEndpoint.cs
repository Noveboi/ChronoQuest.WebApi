using System.Security.Claims;
using ChronoQuest.Endpoints.Chapters.Groups;
using ChronoQuest.Endpoints.Questions.Dto;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters;

internal sealed record GetQuizRequest(
    [property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId,
    [property: RouteParam] Guid ChapterId
);

internal sealed class GetChapterQuestionsEndpoint : Endpoint<GetQuizRequest, QuizDto>
{
    public override void Configure()
    {
        Get("");
        Group<ChapterQuestionGroup>();
    }

    public override async Task HandleAsync(GetQuizRequest req, CancellationToken ct)
    {
        await SendOkAsync(ct);
    }
    
    // Να επιστρέφει question preview dto
}