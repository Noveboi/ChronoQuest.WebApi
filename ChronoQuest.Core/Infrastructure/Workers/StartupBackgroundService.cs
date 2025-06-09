using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ChronoQuest.Core.Infrastructure.Workers;

internal sealed class StartupBackgroundService(IServiceProvider sp) : BackgroundService
{
    private readonly Topic _geography = new("Geography");
    private readonly Topic _history = new("History");
    private readonly Topic _culture = new("Culture");
    
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
        context.Topics.AddRange(GetTopics());
        context.Chapters.AddRange(GetChapters());
        
        await context.SaveChangesAsync(stoppingToken);
        _log.Information("Finished seeding.");
    }

    private IEnumerable<Topic> GetTopics() => [_geography, _history, _culture];

    private IEnumerable<Chapter> GetChapters()
    {
        yield return new Chapter(
            order: 2,
            topic: _geography,
            title: "Geography",
            content: "Lorem ipsum set dolor amet",
            questions: []);
        
        yield return new Chapter(
            order: 1,
            topic: _history,
            title: "History",
            content: "Lorem ipsum set dolor amet",
            questions: []);
        
        yield return new Chapter(
            order: 3,
            topic: _culture,
            title: "Culture",
            content: "Lorem ipsum set dolor amet",
            questions: []);
    }
}