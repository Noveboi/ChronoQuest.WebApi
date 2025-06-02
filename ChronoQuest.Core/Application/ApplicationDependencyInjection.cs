using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Application.Tracking.Store;
using Microsoft.Extensions.DependencyInjection;

namespace ChronoQuest.Core.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) => services
        .AddScoped<TimeTracker>()
        .AddSingleton(typeof(ITrackingStore<,>), typeof(InMemoryTrackingStore<,>));
}