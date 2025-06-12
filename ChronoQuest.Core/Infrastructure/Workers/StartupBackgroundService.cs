using ChronoQuest.Core.Data;
using ChronoQuest.Core.Data.Questions;
using ChronoQuest.Core.Data.Review;
using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ChronoQuest.Core.Infrastructure.Workers;

internal sealed class StartupBackgroundService(IServiceProvider sp) : BackgroundService
{
    private readonly ILogger _log = Log.ForContext<StartupBackgroundService>();
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var scope = sp.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ChronoQuestContext>();

        var pending = await context.Database.GetPendingMigrationsAsync(stoppingToken);
        foreach (var migration in pending)
        {
            _log.Information("Migrating to {migration}", migration);
            await context.Database.MigrateAsync(migration, stoppingToken);
        }
        
        if (await context.Chapters.AnyAsync(stoppingToken))
        {
            _log.Information("Database is seeded.");
            return;
        }
        
        _log.Information("Seeding database with data...");
        context.Topics.AddRange(Topics.All);
        context.Chapters.AddRange(AllChapters.Get());
        context.Questions.AddRange(
            HistoryQuestions.ForExam().Concat(
            GeographyQuestions.ForExam()).Concat(
            CultureQuestions.ForExam()));
        context.ReviewParagraphs.AddRange(
            HistoryReviewParagraphs.All().Concat(
            GeographyReviewParagraphs.All()).Concat(
            CultureReviewParagraphs.All()));
        
        await context.SaveChangesAsync(stoppingToken);
        _log.Information("Finished seeding.");
    }
}