using Microsoft.EntityFrameworkCore.Metadata;

namespace ChronoQuest.Core.Domain.AdaptiveLearning.Metrics;

public enum LearningState
{
    Initial = 0,
    Struggling = 1,
    Improving = 2,
    ActiveLearning = 3,
    Steady = 4,
    Plateau = 5,
    Mastering = 6,
    Mastered = 7
}

public sealed record LearningProgress
{
    public LearningState State { get; private init; } = LearningState.Initial;
    public double Confidence { get; private init; } = 0.5;

    public static LearningProgress Infer(IReadOnlyList<Probability> masteryHistory)
    {
        if (masteryHistory.Count < 3)
        {
            return new LearningProgress();
        }

        var currentMastery = masteryHistory[^1].Value;
        var velocity = LearningVelocity.Calculate(masteryHistory);
        var currentVelocity = velocity.CurrentVelocity;
        var acceleration = velocity.Acceleration;

        return (currentMastery, currentVelocity, acceleration) switch
        {
            (< Constants.Mastery.Beginner, > 0.02, _) => new LearningProgress
            {
                State = LearningState.Improving,
                Confidence = System.Math.Min(0.8, currentVelocity * 20)
            },

            (< Constants.Mastery.Beginner, _, _) => new LearningProgress
            {
                State = LearningState.Struggling,
                Confidence = 0.7
            },

            (< Constants.Mastery.Intermediate, > 0.01, _) => new LearningProgress
            {
                State = LearningState.ActiveLearning,
                Confidence = 0.8
            },

            (< Constants.Mastery.Intermediate, _, < -0.001) => new LearningProgress
            {
                State = LearningState.Plateau,
                Confidence = 0.6
            },

            (< Constants.Mastery.Intermediate, _, _) => new LearningProgress
            {
                State = LearningState.Steady,
                Confidence = 0.7
            },

            (> Constants.Mastery.Master, < 0.005, _) => new LearningProgress
            {
                State = LearningState.Mastered,
                Confidence = 0.9
            },

            _ => new LearningProgress
            {
                State = LearningState.Mastering,
                Confidence = 0.8
            }
        };
    } 
}