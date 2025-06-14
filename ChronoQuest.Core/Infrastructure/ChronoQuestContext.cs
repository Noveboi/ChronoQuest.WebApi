using ChronoQuest.Core.Domain;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Stats;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ChronoQuest.Core.Infrastructure;

public sealed class ChronoQuestContext(DbContextOptions<ChronoQuestContext> options) 
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    private readonly ILogger _log = Log.ForContext<ChronoQuestContext>();
    
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<ChapterReadingTime> ChapterReadings { get; set; }
    
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Question> Questions { get; set; }
    public IQueryable<Question> OrderedQuestions => Questions.OrderBy(x => x.Type);
    
    public DbSet<ReviewMaterial> ReviewMaterial { get; set; }
    public DbSet<ReviewMaterialParagraph> ReviewParagraphs { get; set; }
    
    public DbSet<UserMarker> Markers { get; set; }
    public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfigurationsFromAssembly(typeof(ChronoQuestContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var modifiedCount = ChangeTracker.Entries().Count(x => x.State is not EntityState.Unchanged);
        
        _log.Information("Saving changes... {count} modified entities!", modifiedCount);
        return base.SaveChangesAsync(cancellationToken);
    }
}