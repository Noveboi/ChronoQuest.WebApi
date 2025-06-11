namespace ChronoQuest.Core.Domain.Math;

public static class UtilityExtensions
{
    public static double Max(this double value, double upperLimit) => System.Math.Min(upperLimit, value);
    public static double Min(this double value, double lowerLimit) => System.Math.Max(lowerLimit, value);
}