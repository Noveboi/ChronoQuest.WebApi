using ChronoQuest.Core.Application.Adaptive;
using ChronoQuest.Core.Application.Chapters;
using ChronoQuest.Core.Application.Exams;
using ChronoQuest.Core.Application.ExtraMaterials;
using ChronoQuest.Core.Application.Markers;
using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Application.Tracking.Store;
using Microsoft.Extensions.DependencyInjection;

namespace ChronoQuest.Core.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) => services
        .AddScoped<ChapterStatsService>()
        .AddScoped<QuestionStatsService>()
        .AddScoped<ExamGenerator>()
        .AddScoped<ExtraMaterialGenerator>()
        .AddScoped<IAdaptiveLearning, AdaptiveLearning>()
        .AddScoped<IMarkerService, MarkerService>()
        .AddScoped<IQuestionService, QuestionService>()
        .AddScoped(typeof(ITimeTracker<>), typeof(TimeTracker<>))
        .AddSingleton(typeof(ITrackingStore<>), typeof(InMemoryTrackingStore<>));
}