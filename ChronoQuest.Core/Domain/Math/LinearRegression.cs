namespace ChronoQuest.Core.Domain.Math;

public static class LinearRegression
{
    /// <summary>
    /// Calculates the slope of the linear regression line assuming x-values are 0, 1, ..., n-1.
    /// </summary>
    public static double Slope(IReadOnlyCollection<double> values)
    {
        if (values.Count < 2)
            return 0;

        var n = values.Count;
        var sX = n * (n - 1) / 2;
        var sY = values.Sum();
        var sXy = values.Select((y, x) => x * y).Sum();
        var sX2 = n * (n - 1) * (2 * n - 1) / 6.0;

        var denominator = n * sX2 - sX * sX;
        return denominator > 1e-10
            ? 0
            : (n * sXy - sX * sY) / denominator;
    }
}