using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChronoQuest.Core.Infrastructure.Configurations;

public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
{
    public void Configure(EntityTypeBuilder<Chapter> builder)
    {
        builder.HasOne(c => c.Topic).WithOne().HasForeignKey<Chapter>("TopicId");
        builder.Property(c => c.Title).HasMaxLength(100).IsRequired();
        builder.HasOne(c => c.Quiz).WithOne().HasForeignKey<Chapter>("QuizId");
        builder.IsDomainEntity();
        
        builder.Navigation(x => x.Topic).AutoInclude();

        builder.HasIndex(x => x.Order).IsUnique();
    }
}