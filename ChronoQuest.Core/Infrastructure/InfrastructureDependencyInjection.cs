using System.Threading.Channels;
using ChronoQuest.Core.Application.Markers;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Infrastructure.Workers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace ChronoQuest.Core.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        Log.Information("Configuring Infrastructure . . .");
        
        // Database
        var connectionString = configuration.GetConnectionString("Database") ?? 
                               throw new InvalidOperationException("No 'Database' connection string provided.");
        
        services.AddDbContext<ChronoQuestContext>(options => options.UseNpgsql(connectionString));

        // Identity
        services
            .AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<ChronoQuestContext>();
        
        // Background Services
        services.AddHostedService<StartupBackgroundService>();
        services.AddHostedService<MarkerBackgroundService>();
        
        // Channels
        services.AddSingleton(Channel.CreateUnbounded<UpdateUserMarkerRequest>());
        
        return services;
    }
}