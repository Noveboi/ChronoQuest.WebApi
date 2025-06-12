using Ardalis.Result.AspNetCore;
using ChronoQuest.Core.Application.Progress;
using ChronoQuest.Core.Application.Review;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints.Review.Dto;
using ChronoQuest.Endpoints.Utilities;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Endpoints.Review;

internal sealed class GetReviewMaterialEndpoint(
    ChronoQuestContext dbContext, 
    ReviewMaterialGenerator generator,
    IProgressQueries progress) 
    : Endpoint<GetRequest, ReviewMaterialDto>
{
    public override void Configure()
    {
        Get("review");
    }

    public override async Task HandleAsync(GetRequest req, CancellationToken ct)
    {
        var review = await dbContext
            .ReviewMaterial
            .FirstOrDefaultAsync(e => e.UserId == req.UserId, ct);

        review ??= await GenerateReview(req, ct);
        if (review == null)
            return;
        
        var extraMaterialDto = new ReviewMaterialDto(Id: review.Id, Content: review.Content);
        
        await SendAsync(extraMaterialDto, cancellation: ct);
    }

    private async Task<ReviewMaterial?> GenerateReview(GetRequest req, CancellationToken ct)
    {
        if (await progress.HasCompletedAllChapters(req.UserId, ct) is { IsSuccess: false } result)
        {
            await SendResultAsync(result.ToMinimalApiResult());
            return null;
        }
            
        var review = await generator.GenerateAsync(req.UserId, ct);
        dbContext.Add(review);
        await dbContext.SaveChangesAsync(ct);

        return review;
    }
}