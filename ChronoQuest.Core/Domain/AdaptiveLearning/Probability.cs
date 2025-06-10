namespace ChronoQuest.Core.Domain.AdaptiveLearning;

internal sealed class Probability(double value) : IEquatable<Probability>
{
    public double Value { get; init; } = EnsureInRange(value);

    public static implicit operator Probability(double value) => new(value); 
    
    public static Probability operator +(Probability a, Probability b) => new(a.Value + b.Value);
    public static Probability operator -(Probability a, Probability b) => new(a.Value - b.Value);
    public static Probability operator *(Probability a, Probability b) => new(a.Value * b.Value);
    
    // !!! Division is intentionally missing

    private static double EnsureInRange(double value)
    {
        if (value is < 0 or > 1)
            throw new InvalidOperationException("A probability must be between 0 and 1");

        return value;
    }

    public static bool operator ==(Probability? a, Probability? b)
    {
        if (a is null && b is null)
            return true;

        return a?.Equals(b) ?? false;
    }

    public static bool operator !=(Probability? a, Probability? b) => !(a == b);

    public bool Equals(Probability? other) => other is not null && Value.Equals(other.Value);
    public override bool Equals(object? obj) => obj is Probability prob && Equals(prob);
    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => Value.ToString("P3");
}