namespace ChronoQuest.Core.Domain.Math;

public static class StandardDeviation
{
    public static double Of(IEnumerable<double> vector)
    {
        return System.Math.Sqrt(Variance.Of(vector));
    }
}