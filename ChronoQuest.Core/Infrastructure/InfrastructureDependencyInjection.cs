using ChronoQuest.Core.Domain;
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
        var connectionString = configuration.GetConnectionString("Database");
        if (connectionString is null)
            throw new InvalidOperationException("No 'Database' connection string provided.");
        // DbContext
        services.AddDbContext<ChronoQuestContext>((options) => options.UseNpgsql(connectionString));
        // Identity
        services.AddIdentityCore<User>().AddEntityFrameworkStores<ChronoQuestContext>();
        return services;
    }
}