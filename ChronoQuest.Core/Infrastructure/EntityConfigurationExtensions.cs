using ChronoQuest.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChronoQuest.Core.Infrastructure;

public static class EntityConfigurationExtensions
{
    public static void IsDomainEntity<T>(this EntityTypeBuilder<T> builder) where T : Entity
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedNever();
    }
}