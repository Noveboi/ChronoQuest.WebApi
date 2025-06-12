using System.Security.Claims;
using ChronoQuest.Core.Application;
using ChronoQuest.Core.Application.Markers;
using ChronoQuest.Core.Domain;
using ChronoQuest.Endpoints.Utilities.Attributes;
using ChronoQuest.Endpoints.Utilities.Dto;
using FastEndpoints;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ChronoQuest.Endpoints.Utilities;

internal sealed record GetUserMarkerRequest([property: UserId] Guid UserId);
internal sealed class GetUserMarkerEndpoint(IMarkerService markers) : Endpoint<GetUserMarkerRequest, UserMarkerDto>
{
    public override void Configure()
    {
        Get("/marker");
    }

    public override async Task HandleAsync(GetUserMarkerRequest req, CancellationToken ct)
    {
        var marker = await markers.GetAsync(req.UserId, ct);
        LogMarkerStatus(marker, req.UserId);
        
        await SendAsync(marker.ToDto(), cancellation: ct);
    }

    private void LogMarkerStatus(UserMarker? marker, Guid userId)
    {
        if (marker == null)
        {
            Logger.LogInformation("No marker found for {userId}", userId);
        }
        else
        {
            Logger.LogInformation("Found marker for {userId} {@marker}", userId, marker);
        }
    }
}