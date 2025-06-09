using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Stats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChronoQuest.Core.Infrastructure.Configurations.Stats;

public class QuestionAnswerConfiguration : IEntityTypeConfiguration<QuestionAnswer>
{
    public void Configure(EntityTypeBuilder<QuestionAnswer> builder)
    {
        builder.IsDomainEntity();
        
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
        builder.HasOne<Question>().WithMany(x => x.Answers).HasForeignKey(x => x.QuestionId);
        builder.HasOne<Option>().WithMany().HasForeignKey(x => x.OptionId);
    }
}