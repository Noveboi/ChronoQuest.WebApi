using ChronoQuest.Common;

namespace ChronoQuest.Core.Domain.AdaptiveLearning;

/// <summary>
/// A user's mastery of a specific skill in a point in time.
/// </summary>
internal sealed class UserSkillMastery(
    Guid modelId,
    DateTimeOffset dateTime, 
    Probability probabilityOfMastery) : Entity
{
    /// <summary>
    /// A reference to the <see cref="BayesianKnowledgeTracingModel"/>
    /// </summary>
    public Guid ModelId { get; private init; } = modelId;
    public DateTime UtcDateTime { get; private init; } = dateTime.UtcDateTime;
    public Probability ProbabilityOfMastery { get; private init; } = probabilityOfMastery;
}