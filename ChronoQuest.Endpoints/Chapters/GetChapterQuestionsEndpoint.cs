using System.Security.Claims;
using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Endpoints.Chapters.Groups;
using ChronoQuest.Endpoints.Questions.Dto;
using ChronoQuest.Endpoints.Utilities.Attributes;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters;

internal sealed record GetQuizRequest(
    [property: UserId] Guid UserId,
    [property: RouteParam] Guid ChapterId
);

internal sealed class GetChapterQuestionsEndpoint(IQuestionService service) 
    : Endpoint<GetQuizRequest, IEnumerable<QuestionPreviewDto>>
{
    public override void Configure()
    {
        Get("");
        Group<ChapterQuestionGroup>();
    }

    public override async Task HandleAsync(GetQuizRequest req, CancellationToken ct)
    {
        var request = new QuestionsForChapterRequest(ChapterId: req.ChapterId, UserId: req.UserId);
        var questions = await service.GetQuestionsForChapterAsync(request, ct);
        
        await SendOkAsync(questions.Select(x => x.ToPreviewDto(req.UserId)), cancellation: ct);
    }
}