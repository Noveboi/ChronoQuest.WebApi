using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ChronoQuest.Endpoints;

public static class EndpointsDependencyInjection
{
    public static IServiceCollection AddChronoQuestEndpoints(this IServiceCollection services)
    {
        return services.AddFastEndpoints();
    }

    public static void MapChronoQuestEndpoints(this IApplicationBuilder app)
    {
        app.UseFastEndpoints();
    }
}