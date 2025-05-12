using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Core.Infrastructure;

internal sealed class ChronoDbContext(DbContextOptions<ChronoDbContext> options) : DbContext(options)
{
    
}