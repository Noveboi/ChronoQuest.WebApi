using ChronoQuest.Core.Application.Review;
using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints.Review.Dto;
using ChronoQuest.Endpoints.Utilities;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Endpoints.Review;

internal sealed class GetReviewMaterialEndpoint(ChronoQuestContext dbContext, ReviewMaterialGenerator generator) 
    : Endpoint<GetRequest, ReviewMaterialDto>
{
    public override void Configure()
    {
        Get("extra-material");
    }

    public override async Task HandleAsync(GetRequest req, CancellationToken ct)
    {
        var extraMaterial = await dbContext
            .ExtraMaterial
            .FirstOrDefaultAsync(e => e.UserId == req.UserId, ct);

        if (extraMaterial == null)
        {
            extraMaterial = await generator.GenerateAsync(req.UserId, ct);
            dbContext.Add(extraMaterial);
            await dbContext.SaveChangesAsync(ct);
        }
        
        var extraMaterialDto = new ReviewMaterialDto(Id: extraMaterial.Id, Content: extraMaterial.Content);
        
        await SendAsync(extraMaterialDto, cancellation: ct);
    }
}