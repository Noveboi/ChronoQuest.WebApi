using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Stats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChronoQuest.Core.Infrastructure.Configurations.Stats;

internal sealed class ChapterReadingTimeConfiguration : IEntityTypeConfiguration<ChapterReadingTime>
{
    public void Configure(EntityTypeBuilder<ChapterReadingTime> builder)
    {
        builder.IsDomainEntity();
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Chapter).WithMany(x => x.Readings).HasForeignKey(x => x.ChapterId);

        builder.HasIndex(x => x.UserId);
    }
}