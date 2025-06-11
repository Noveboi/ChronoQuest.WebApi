using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Application.Exams;

public sealed class TakeQuestionsForTopicDecision
{
    private Dictionary<Difficulty, int> _questionsPerDifficulty;
    private readonly int _totalQuestions;

    public TakeQuestionsForTopicDecision(Topic topic, int totalQuestions)
    {
        Topic = topic;
        _totalQuestions = Math.Min(8, Math.Max(3, totalQuestions));
            
        var difficulties = Enum.GetValues<Difficulty>();
        var questionsPerDifficulty = totalQuestions / difficulties.Length;

        _questionsPerDifficulty = difficulties.ToDictionary(
            x => x,
            _ => questionsPerDifficulty);
    }

    public Topic Topic { get; }
        
    public int NumberOfQuestionsFor(Difficulty diff) => _questionsPerDifficulty[diff];

    public TakeQuestionsForTopicDecision Distribute(int easyPercentage, int mediumPercentage, int hardPercentage)
    {
        if (easyPercentage + mediumPercentage + hardPercentage != 100)
        {
            throw new InvalidOperationException("Percentages should sum to 100%");
        }
            
        var easy = _totalQuestions * easyPercentage / 100.0;
        var medium = _totalQuestions * mediumPercentage / 100.0;
        var hard = _totalQuestions * hardPercentage / 100.0;

        var e = (int)Math.Floor(easy);
        var m = (int)Math.Floor(medium);
        var h = (int)Math.Floor(hard);

        var totalAssigned = e + m + h;
        var remaining = _totalQuestions - totalAssigned;

        var remainders = new[]
            {
                easy - e,
                medium - m,
                hard - h
            }
            .Index()
            .OrderByDescending(r => r.Item)
            .ToArray();

        var buckets = new[] { e, m, h };
            
        for (var i = 0; i < remaining; i++)
        {
            buckets[remainders[i].Index]++;
        }

        _questionsPerDifficulty = new Dictionary<Difficulty, int>
        {
            [Difficulty.Easy] = buckets[0],
            [Difficulty.Medium] = buckets[1],
            [Difficulty.Hard] = buckets[2]
        };

        return this;
    }
}