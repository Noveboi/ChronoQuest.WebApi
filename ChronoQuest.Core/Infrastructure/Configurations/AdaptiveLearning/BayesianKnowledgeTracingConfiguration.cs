using ChronoQuest.Core.Domain.AdaptiveLearning;
using ChronoQuest.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChronoQuest.Core.Infrastructure.Configurations.AdaptiveLearning;

internal sealed class BayesianKnowledgeTracingConfiguration : IEntityTypeConfiguration<BayesianKnowledgeTracingModel>
{
    public void Configure(EntityTypeBuilder<BayesianKnowledgeTracingModel> builder)
    {
        builder.IsDomainEntity();
        
        builder.Probability(x => x.InitialKnowledgeProbability);
        builder.Probability(x => x.LearningProbability);
        builder.Probability(x => x.SlipProbability);
        builder.Probability(x => x.GuessProbability);

        builder.HasMany(x => x.MasteryHistory).WithOne().HasForeignKey(x => x.ModelId);
        builder.HasOne<User>().WithOne().HasForeignKey<BayesianKnowledgeTracingModel>(x => x.UserId);
        builder.HasOne(x => x.Topic).WithMany().HasForeignKey(x => x.TopicId);

        builder.Navigation(x => x.MasteryHistory).AutoInclude();
    }
}