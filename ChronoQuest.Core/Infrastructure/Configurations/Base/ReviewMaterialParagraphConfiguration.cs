using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChronoQuest.Core.Infrastructure.Configurations.Base;

public sealed class ReviewMaterialParagraphConfiguration : IEntityTypeConfiguration<ReviewMaterialParagraph>
{
    public void Configure(EntityTypeBuilder<ReviewMaterialParagraph> builder)
    {
        builder.IsDomainEntity();
        builder.HasOne(x => x.Topic).WithMany();
    }
}