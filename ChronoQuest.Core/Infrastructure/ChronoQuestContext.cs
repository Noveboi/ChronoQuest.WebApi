using Microsoft.EntityFrameworkCore;

namespace ChronoQuest.Core.Infrastructure;

internal class ChronoQuestContext(DbContextOptions<ChronoQuestContext> options) : DbContext(options)
{
    
}