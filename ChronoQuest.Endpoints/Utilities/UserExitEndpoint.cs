using System.Security.Claims;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Utilities;


internal sealed record UserExitRequest([property: FromClaim(ClaimTypes.NameIdentifier)] Guid UserId);

/// <summary>
/// Called when the is exiting the application. 
/// </summary>
internal sealed class UserExitEndpoint : Endpoint<UserExitRequest>
{
    public override void Configure()
    {
        Get("exit");
    }

    public override Task HandleAsync(UserExitRequest req, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}