using ChronoQuest.Core.Application.Chapters;
using Microsoft.Extensions.DependencyInjection;

namespace ChronoQuest.Core.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) => services
        .AddScoped<IUserActionTracker<ChapterTrackingInformation>, ChapterReadingTracker>()
        .AddSingleton(typeof(ITrackingStore<,>), typeof(InMemoryTrackingStore<,>));
}