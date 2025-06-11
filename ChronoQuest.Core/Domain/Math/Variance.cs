namespace ChronoQuest.Core.Domain.Math;

public static class Variance
{
    public static double Of(IEnumerable<double> vector)
    {
        var list = vector as IReadOnlyList<double> ?? vector.ToList();
        
        var n = list.Count;
        if (n == 0)
        {
            return 0;
        }
        
        var mean = list.Average();
        return list.Sum(x => System.Math.Pow(x - mean, 2)) / n;
    }
}