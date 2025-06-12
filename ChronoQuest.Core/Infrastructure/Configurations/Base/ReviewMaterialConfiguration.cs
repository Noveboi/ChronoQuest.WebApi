using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChronoQuest.Core.Infrastructure.Configurations.Base;

public class ReviewMaterialConfiguration : IEntityTypeConfiguration<ReviewMaterial>
{
    public void Configure(EntityTypeBuilder<ReviewMaterial> builder)
    {
        builder.HasOne<User>().WithOne().HasForeignKey<ReviewMaterial>(e => e.UserId);
        builder.IsDomainEntity();
    }
}