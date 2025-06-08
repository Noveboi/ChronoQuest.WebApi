using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChronoQuest.Core.Infrastructure.Configurations.Base;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.IsDomainEntity();
        
        builder.HasOne(q => q.Topic).WithMany();
        builder.Property(q => q.Content).HasMaxLength(200).IsRequired();
        builder.OwnsMany(q => q.Options, navigationBuilder =>
        {
            navigationBuilder.Property(q => q.Content).HasMaxLength(100).IsRequired();
        });
    }
}