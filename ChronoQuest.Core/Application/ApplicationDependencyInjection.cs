using ChronoQuest.Core.Application.Chapters;
using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Application.Tracking.Store;
using Microsoft.Extensions.DependencyInjection;

namespace ChronoQuest.Core.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) => services
        .AddScoped<ChapterStatsService>()
        .AddScoped(typeof(TimeTracker<>))
        .AddScoped(typeof(ITimeTracker<>), typeof(EntityTimeTracker<>))
        .AddSingleton(typeof(ITrackingStore<>), typeof(InMemoryTrackingStore<>));
}