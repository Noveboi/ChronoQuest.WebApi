using ChronoQuest.Core.Domain.Base;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Core.Infrastructure;

internal class ChronoQuestContext(DbContextOptions<ChronoQuestContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Question> Questions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ChronoQuestContext).Assembly);
    }
}