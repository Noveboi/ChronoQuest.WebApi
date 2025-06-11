using ChronoQuest.Core.Domain.Stats;

namespace ChronoQuest.Core.Domain.AdaptiveLearning.Metrics;

public sealed record LearningStreak(
    int CurrentCorrect,
    int CurrentIncorrect,
    int MaxCorrect,
    int MaxIncorrect)
{
    public static readonly LearningStreak Default = new(0, 0, 0, 0);

    public static LearningStreak Calculate(IReadOnlyList<QuestionAnswer> answers)
    {
        if (answers.Count == 0)
        {
            return Default;
        }

        var currentCorrect = 0;
        var currentIncorrect = 0;

        for (var i = answers.Count - 1; i >= 0; i--)
        {
            if (answers[i].IsCorrect && currentIncorrect == 0)
                currentCorrect++;
            else if (!answers[i].IsCorrect && currentCorrect == 0)
                currentIncorrect++;
            else
                break;
        }

        var maxCorrect = 0;
        var maxIncorrect = 0;
        var tempCorrect = 0;
        var tempIncorrect = 0;
        
        foreach (var answer in answers)
        {
            if (answer.IsCorrect)
            {
                tempCorrect++;
                tempIncorrect = 0;
                maxCorrect = System.Math.Max(maxCorrect, tempCorrect);
            }
            else
            {
                tempIncorrect++;
                tempCorrect = 0;
                maxIncorrect = System.Math.Max(maxIncorrect, tempIncorrect);
            }
        }

        return new LearningStreak(
            CurrentCorrect: currentCorrect,
            CurrentIncorrect: currentIncorrect,
            MaxCorrect: maxCorrect,
            MaxIncorrect: maxIncorrect);
    }
}