using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChronoQuest.Core.Infrastructure.Configurations.Base;

public class ExtraMaterialConfigurations : IEntityTypeConfiguration<ExtraMaterial>
{
    public void Configure(EntityTypeBuilder<ExtraMaterial> builder)
    {
        builder.HasOne(e => e.User).WithOne().HasForeignKey<ExtraMaterial>("UserId");
        builder.Property(c => c.Content).HasMaxLength(500).IsRequired();
        builder.IsDomainEntity();
    }
}