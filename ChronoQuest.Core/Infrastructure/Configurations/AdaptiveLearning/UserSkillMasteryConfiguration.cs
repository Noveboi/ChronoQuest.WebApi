using ChronoQuest.Core.Domain.AdaptiveLearning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChronoQuest.Core.Infrastructure.Configurations.AdaptiveLearning;

internal sealed class UserSkillMasteryConfiguration : IEntityTypeConfiguration<UserSkillMastery>
{
    public void Configure(EntityTypeBuilder<UserSkillMastery> builder)
    {
        builder.IsDomainEntity();
        builder.Probability(x => x.ProbabilityOfMastery);
    }
}