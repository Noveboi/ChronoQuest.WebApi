using System.Security.Claims;
using ChronoQuest.Core.Application.Tracking;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Utilities;
internal sealed record UserExitRequest([property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId);

/// <summary>
/// Called when the is exiting the application. 
/// </summary>
internal sealed class UserExitEndpoint(TimeTracker tracker) : Endpoint<UserExitRequest>
{
    public override void Configure()
    {
        Get("exit");
    }

    public override async Task HandleAsync(UserExitRequest req, CancellationToken ct)
    {
        await tracker.StopTrackingEntirelyAsync(req.UserId, ct);
        await SendOkAsync(ct);
    }
}