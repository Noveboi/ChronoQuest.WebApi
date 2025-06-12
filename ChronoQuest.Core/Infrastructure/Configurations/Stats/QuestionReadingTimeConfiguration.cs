using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Stats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChronoQuest.Core.Infrastructure.Configurations.Stats;

internal sealed class QuestionReadingTimeConfiguration : IEntityTypeConfiguration<QuestionReadingTime>
{
    public void Configure(EntityTypeBuilder<QuestionReadingTime> builder)
    {
        builder.IsDomainEntity();
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Question).WithMany(q => q.ReadingTime).HasForeignKey(x => x.QuestionId);

        builder.HasIndex(x => x.QuestionId);
    }
}