using ChronoQuest.Common;
using ChronoQuest.Core.Domain;
using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChronoQuest.Core.Infrastructure.Configurations;

internal sealed class UserMarkerConfiguration : IEntityTypeConfiguration<UserMarker>
{
    public void Configure(EntityTypeBuilder<UserMarker> builder)
    {
        builder.IsDomainEntity();
        builder.HasIndex(x => x.UserId).IsUnique();

        builder.HasOne<User>().WithOne().HasForeignKey<UserMarker>(x => x.UserId);
        builder.HasOne<Exam>().WithOne().IsRequired(false).HasForeignKey<UserMarker>(x => x.ExamId);
        builder.HasOne<Chapter>().WithMany().IsRequired(false).HasForeignKey(x => x.ChapterId);
        builder.HasOne<Question>().WithMany().IsRequired(false).HasForeignKey(x => x.QuestionId);
    }
}