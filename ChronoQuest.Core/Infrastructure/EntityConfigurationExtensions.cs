using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChronoQuest.Common;

public static class EntityConfigurationExtensions
{
    public static void IsDomainEntity<T>(this EntityTypeBuilder<T> builder) where T : Entity
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedNever();
    }
}