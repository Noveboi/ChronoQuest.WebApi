using ChronoQuest.Core.Domain.Math;

namespace ChronoQuest.Core.Domain.AdaptiveLearning.Metrics;

public sealed class ErrorClustering
{
    public double Value { get; private init; }
    
    public static ErrorClustering Analyze(IEnumerable<bool> responses, int windowSize = 5)
    {
        var list = responses as IReadOnlyList<bool> ?? responses.ToList();
        if (list.Count < windowSize)
            return new ErrorClustering();

        var densities = new List<double>(capacity: list.Count);

        for (var i = 0; i <= list.Count - windowSize; i++)
        {
            var window = list.Skip(i).Take(windowSize);
            var density = 1 - window.Count(x => x) / (double)windowSize;
            densities.Add(density);
        }

        return new ErrorClustering
        {
            Value = Variance.Of(densities)
        };
    }
}