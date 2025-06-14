﻿using ChronoQuest.Core.Domain.Math;
using ChronoQuest.Core.Domain.Stats;

namespace ChronoQuest.Core.Domain.AdaptiveLearning.Metrics;

public sealed record ResponsePatternAnalysis
{
    public double OverallAccuracy { get; private init; }
    public ErrorClustering ErrorClustering { get; private init; } = new();
    public Stability Stability { get; private init; } = new();
    
    public static ResponsePatternAnalysis Get(IReadOnlyList<QuestionAnswer> answers, int windowSize = 5)
    {
        if (answers.Count == 0)
        {
            return new ResponsePatternAnalysis();
        }

        var accuracy = answers.Count(a => a.IsCorrect) / (double)answers.Count;
        var recentWindow = int.Min(windowSize, answers.Count);
        var recentAccuracy = answers.TakeLast(recentWindow).Count(a => a.IsCorrect) / (double)recentWindow;
        
        var responses = answers.Select(x => x.IsCorrect).ToList();

        return new ResponsePatternAnalysis()
        {
            OverallAccuracy = accuracy,
            ErrorClustering = ErrorClustering.Analyze(responses),
            Stability = Stability.Calculate(responses),
        };
    }
}