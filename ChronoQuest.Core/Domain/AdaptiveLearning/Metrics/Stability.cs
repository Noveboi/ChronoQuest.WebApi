using ChronoQuest.Core.Domain.Math;

namespace ChronoQuest.Core.Domain.AdaptiveLearning.Metrics;

public sealed class Stability
{
    public double Value { get; private init; } = 1;
    public bool IsStable => Value >= 0.5;
    
    public static Stability Calculate(IEnumerable<bool> responses, int windowSize = 5)
    {
        var list = responses as IReadOnlyList<bool> ?? responses.ToList();
        if (list.Count < windowSize)
        {
            return new Stability();
        }

        var accuracies = new List<double>();
        for (var i = 0; i <= list.Count - windowSize; i++)
        {
            var window = list.Skip(i).Take(windowSize);
            var accuracy = window.Count(x => x) / (double)windowSize;
            accuracies.Add(accuracy);
        }

        if (accuracies.Count <= 1 || accuracies.Average() is var average && average == 0)
            return new Stability();

        var cv = StandardDeviation.Of(accuracies) / average;
        return new Stability
        {
            Value = 1 / (1 + cv) // normalize to [0, 1]
        };
    }
}