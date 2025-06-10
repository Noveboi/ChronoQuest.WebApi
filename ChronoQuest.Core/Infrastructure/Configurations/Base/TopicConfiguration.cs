using ChronoQuest.Common;
using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChronoQuest.Core.Infrastructure.Configurations.Base;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.Property(t => t.Name).HasMaxLength(50).IsRequired();
        builder.IsDomainEntity();
    }
}