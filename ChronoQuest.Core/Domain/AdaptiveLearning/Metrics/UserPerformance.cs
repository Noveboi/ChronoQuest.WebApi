using ChronoQuest.Core.Domain.Base;
using ChronoQuest.Core.Domain.Math;
using ChronoQuest.Core.Domain.Stats;

namespace ChronoQuest.Core.Domain.AdaptiveLearning.Metrics;

public sealed record UserPerformance
{
    public double TotalScore { get; private init; }
    public double MasteryScore { get; private init; }
    public double VelocityScore { get; private init; }
    public double EfficiencyScore { get; private init; }
    public double ConsistencyScore { get; private init; }

    public LearningProgress LearningProgress { get; private init; } = new();
    
    internal static UserPerformance Analyze(
        BayesianKnowledgeTracingModel model,
        IEnumerable<QuestionAnswer> answers)
    {
        var masteryHistory = model.MasteryHistory.Select(x => x.ProbabilityOfMastery).ToList();
        var answerList = answers as IReadOnlyList<QuestionAnswer> ?? answers.ToList();
        
        var velocity = LearningVelocity.Calculate(masteryHistory);
        var patterns = ResponsePatternAnalysis.Get(answerList);
        var efficiency = Efficiency.Calculate(masteryHistory, answerList);
        
        var masteryScore = (patterns.OverallAccuracy * 40).Max(40);
        var velocityScore = (velocity.CurrentVelocity * 200 + 10).Min(0).Max(20);
        var efficiencyScore = (efficiency.Value * 20).Max(20);
        var consistencyScore = (patterns.Stability.Value * 20).Max(20);

        var totalScore = (masteryScore + velocityScore + efficiencyScore + consistencyScore)
            .Min(0)
            .Max(100);

        return new UserPerformance
        {
            TotalScore = totalScore,
            MasteryScore = masteryScore,
            ConsistencyScore = consistencyScore,
            EfficiencyScore = efficiencyScore,
            VelocityScore = velocityScore,
            LearningProgress = LearningProgress.Infer(masteryHistory)
        };
    }

    public override string ToString() => $"T: {TotalScore:N} | " +
                                         $"M: {MasteryScore:N} | " +
                                         $"C: {ConsistencyScore:N} | " +
                                         $"E: {EfficiencyScore:N} | " +
                                         $"V: {VelocityScore:N}";
}