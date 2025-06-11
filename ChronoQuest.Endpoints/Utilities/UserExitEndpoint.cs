using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints.Utilities.Attributes;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Utilities;
internal sealed record UserExitRequest([property: UserId] Guid UserId);

/// <summary>
/// Called when the is exiting the application. 
/// </summary>
internal sealed class UserExitEndpoint(
    IEnumerable<ITerminateTracking> trackingTerminators,
    ChronoQuestContext context) : Endpoint<UserExitRequest>
{
    public override void Configure()
    {
        Get("exit");
    }

    public override async Task HandleAsync(UserExitRequest req, CancellationToken ct)
    {
        foreach (var terminator in trackingTerminators)
        {
            await terminator.TerminateTrackingAsync(req.UserId, ct);
        }
        
        await context.SaveChangesAsync(ct);
        await SendOkAsync(ct);
    }
}