using ChronoQuest.Core.Application.ExtraMaterials;
using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints.ExtraMaterial.Dto;
using ChronoQuest.Endpoints.Utilities;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Endpoints.ExtraMaterial;

internal sealed class GetExtraMaterialEndpoint(ChronoQuestContext dbContext, ExtraMaterialGenerator generator) : Endpoint<GetRequest, ExtraMaterialDto>
{
    // Two cases:
    // - Case 1: Extra material for user exists! Simply return the material as a DTO
    // - Case 2: Extra material for user does not exist! First generate the material, add it to the DB and then return 
    //           it as a DTO.

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
        
        var extraMaterialDto = new ExtraMaterialDto(Id: extraMaterial.Id, Content: extraMaterial.Content);
        
        await SendAsync(extraMaterialDto, cancellation: ct);
    }
}