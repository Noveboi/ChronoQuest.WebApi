using ChronoQuest.Core.Application.Chapters;
using ChronoQuest.Core.Application.Markers;
using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Application.Tracking.Store;
using Microsoft.Extensions.DependencyInjection;

namespace ChronoQuest.Core.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) => services
        .AddScoped<IMarkerService, MarkerService>()
        .AddScoped<ChapterStatsService>()
        .AddScoped(typeof(ITimeTracker<>), typeof(TimeTracker<>))
        .AddScoped<IQuestionService, QuestionService>()
        .AddSingleton(typeof(ITrackingStore<>), typeof(InMemoryTrackingStore<>));
}