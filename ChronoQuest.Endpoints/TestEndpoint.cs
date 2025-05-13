using FastEndpoints;

namespace ChronoQuest.Endpoints;

public class TestEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendStringAsync("Hello Passgres!");
    }
}