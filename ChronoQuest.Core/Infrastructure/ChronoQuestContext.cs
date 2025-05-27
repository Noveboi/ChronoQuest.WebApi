using ChronoQuest.Core.Domain.Base;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Core.Infrastructure;

internal class ChronoQuestContext(DbContextOptions<ChronoQuestContext> options) : IdentityDbContext<User>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ChronoQuestContext).Assembly);
    }
}