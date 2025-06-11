using ChronoQuest.Core.Domain.Math;

namespace ChronoQuest.Core.Domain.AdaptiveLearning.Metrics;

public sealed record LearningVelocity
{
    public double CurrentVelocity { get; private init; }
    public double AverageVelocity { get; private init; }
    public double Acceleration { get; private init; }
    public IReadOnlyList<double> VelocityHistory { get; private init; } = [];

    public static LearningVelocity Calculate(IReadOnlyList<Probability> masteryHistory, int windowSize = 5)
    {
        if (masteryHistory.Count < 2)
        {
            return new LearningVelocity();
        }

        // Calculate point-to-point velocity (change in mastery per opportunity)
        var velocities = new List<double>();
        for (var i = 1; i < masteryHistory.Count; i++)
        {
            var velocity = masteryHistory[i].Value - masteryHistory[i - 1].Value;
            velocities.Add(velocity);
        }

        // Current velocity (average of last windowSize velocities)
        var recentVelocities = velocities.TakeLast(windowSize).ToArray();
        var currentVelocity = recentVelocities.Length != 0 ? recentVelocities.Average() : 0.0;

        // Average velocity across all learning
        var avgVelocity = velocities.Count != 0 ? velocities.Average() : 0.0;

        var acceleration = LinearRegression.Slope(velocities);

        return new LearningVelocity
        {
            CurrentVelocity = currentVelocity,
            AverageVelocity = avgVelocity,
            Acceleration = acceleration,
            VelocityHistory = velocities
        };
    }
}