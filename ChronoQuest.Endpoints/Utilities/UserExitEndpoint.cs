using System.Security.Claims;
using ChronoQuest.Core.Application.Tracking.Requests;
using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints.Utilities.Attributes;
using FastEndpoints;
using MediatR;

namespace ChronoQuest.Endpoints.Utilities;
internal sealed record UserExitRequest([property: UserId] Guid UserId);

/// <summary>
/// Called when the is exiting the application. 
/// </summary>
internal sealed class UserExitEndpoint(IPublisher publisher, ChronoQuestContext context) : Endpoint<UserExitRequest>
{
    public override void Configure()
    {
        Get("exit");
    }

    public override async Task HandleAsync(UserExitRequest req, CancellationToken ct)
    {
        await publisher.Publish(new StopTrackingEverything(UserId: req.UserId), ct);
        await context.SaveChangesAsync(ct);
        await SendOkAsync(ct);
    }
}