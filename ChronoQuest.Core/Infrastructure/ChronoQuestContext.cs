using ChronoQuest.Core.Domain;
using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Stats;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Core.Infrastructure;

public sealed class ChronoQuestContext(DbContextOptions<ChronoQuestContext> options) 
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<ChapterReadingTime> ChapterReadings { get; set; }
    
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Question> Questions { get; set; }
    
    public DbSet<UserMarker> Markers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ChronoQuestContext).Assembly);
    }
}