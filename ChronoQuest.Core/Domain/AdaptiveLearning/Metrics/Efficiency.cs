using ChronoQuest.Core.Domain.Stats;

namespace ChronoQuest.Core.Domain.AdaptiveLearning.Metrics;

public enum EfficiencyStatus
{
    NeedsImprovement = 0,
    Good = 1,
    Excellent = 2
}

public sealed record Efficiency
{
    public double Value { get; private init; }

    public EfficiencyStatus Status => Value switch
    {
        < 0.7 => EfficiencyStatus.NeedsImprovement,
        > 1.5 => EfficiencyStatus.Excellent,
        _ => EfficiencyStatus.Good
    };

    public static Efficiency Calculate(
        IReadOnlyList<Probability> masteryHistory, 
        IReadOnlyList<QuestionAnswer> answers,
        int expectedAttempts = 10)
    {
        if (masteryHistory.Count == 0 || answers.Count == 0 || answers.Count is var attemptsMade && attemptsMade == 0)
            return new Efficiency { Value = 1 };
        
        var currentMastery = masteryHistory[^1].Value;
        var expectedMastery = 1 - System.Math.Exp(-(double)attemptsMade / expectedAttempts);

        return new Efficiency
        {
            Value = expectedMastery > 0 ? currentMastery / expectedMastery : 1
        };
    }
}