using ChronoQuest.Core.Domain.Base;
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
        services.AddHostedService<StartupService>();

        // Identity
        services
            .AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<ChronoQuestContext>();
        
        return services;
    }
}