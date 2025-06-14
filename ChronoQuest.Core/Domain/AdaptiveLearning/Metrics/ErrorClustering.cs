namespace ChronoQuest.Core.Domain.AdaptiveLearning.Metrics;

public sealed class ErrorClustering
{
    public double Variance { get; private init; }
    
    public static ErrorClustering Analyze(IEnumerable<bool> responses, int windowSize = 5)
    {
        var list = responses as IReadOnlyList<bool> ?? responses.ToList();
        if (list.Count < windowSize)
            return new ErrorClustering();

        var localDensities = new List<double>(capacity: list.Count);

        for (var i = 0; i <= list.Count - windowSize; i++)
        {
            var window = list.Skip(i).Take(windowSize);
            var localDensity = 1 - window.Count(x => x) / (double)windowSize;
            localDensities.Add(localDensity);
        }

        return new ErrorClustering
        {
            Variance = Math.Variance.Of(localDensities)
        };
    }
}