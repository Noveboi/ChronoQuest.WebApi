using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ChronoQuest.Core;

internal sealed class StartupService(IServiceProvider sp) : BackgroundService
{
    private readonly Topic _geography = new("Geography");
    private readonly Topic _history = new("History");
    private readonly Topic _culture = new("Culture");
    
    private readonly ILogger _log = Log.ForContext<StartupService>();
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var scope = sp.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ChronoQuestContext>();
        
        await context.Database.MigrateAsync(stoppingToken);
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
            topic: _geography,
            title: "Geography",
            content: "Lorem ipsum set dolor amet",
            quiz: new Quiz([]));
        
        yield return new Chapter(
            topic: _history,
            title: "History",
            content: "Lorem ipsum set dolor amet",
            quiz: new Quiz([]));
        
        yield return new Chapter(
            topic: _culture,
            title: "Culture",
            content: "Lorem ipsum set dolor amet",
            quiz: new Quiz([]));
    }
}