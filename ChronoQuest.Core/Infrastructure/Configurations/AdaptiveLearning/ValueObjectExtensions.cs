using System.Linq.Expressions;
using ChronoQuest.Core.Domain.AdaptiveLearning;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChronoQuest.Core.Infrastructure.Configurations.AdaptiveLearning;

internal static class ValueObjectExtensions
{
    public static void Probability<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, Probability>> propertyExpression) where T : class
    {
        builder
            .Property(propertyExpression)
            .HasConversion(
                convertToProviderExpression: p => p.Value,
                convertFromProviderExpression: x => new Probability(x));
    }
}