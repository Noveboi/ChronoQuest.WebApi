using ChronoQuest.Core.Application.Adaptive;
using ChronoQuest.Core.Application.Chapters;
using ChronoQuest.Core.Application.Exams;
using ChronoQuest.Core.Application.Markers;
using ChronoQuest.Core.Application.Questions;
using ChronoQuest.Core.Application.Review;
using ChronoQuest.Core.Application.Tracking;
using ChronoQuest.Core.Application.Tracking.Store;
using ChronoQuest.Core.Domain.Stats;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace ChronoQuest.Core.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) =>
        services
            .AddScoped<ChapterStatsService>()
            .AddScoped<QuestionStatsService>()
            .AddScoped<ExamGenerator>()
            .AddScoped<ReviewMaterialGenerator>()
            .AddScoped<IAdaptiveLearning, AdaptiveLearning>()
            .AddScoped<IMarkerService, MarkerService>()
            .AddScoped<IQuestionService, QuestionService>()
            .AddTracker<ChapterReadingTime>()
            .AddTracker<QuestionReadingTime>()
            .AddScoped(typeof(ITimeTracker<>), typeof(TimeTracker<>))
            .AddSingleton(typeof(ITrackingStore<>), typeof(InMemoryTrackingStore<>));
}