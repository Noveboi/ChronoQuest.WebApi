namespace ChronoQuest.Core.Domain.AdaptiveLearning;

/// <summary>
/// A user's mastery of a specific skill in a point in time.
/// </summary>
internal sealed class UserSkillMastery : Entity
{
    private UserSkillMastery() { }
    internal UserSkillMastery(
        Guid modelId,
        DateTimeOffset dateTime, 
        Probability probabilityOfMastery)
    {
        ModelId = modelId;
        UtcDateTime = dateTime.UtcDateTime;
        ProbabilityOfMastery = probabilityOfMastery;
    }

    /// <summary>
    /// A reference to the <see cref="BayesianKnowledgeTracingModel"/>
    /// </summary>
    public Guid ModelId { get; private init; }
    public DateTime UtcDateTime { get; private init; }
    public Probability ProbabilityOfMastery { get; private init; } = null!;
}