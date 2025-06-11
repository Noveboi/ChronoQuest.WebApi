using ChronoQuest.Core.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ChronoQuest.Core.Application.Tracking;

public static class TrackingServiceExtensions
{
    public static IServiceCollection AddTracker<T>(this IServiceCollection services) 
        where T : class, ITimeTrackingEntity<T>
    {
        services.AddScoped<ITimeTracker<T>, TimeTracker<T>>();
        services.AddScoped<ITerminateTracking, TimeTracker<T>>();
        return services;
    }
}