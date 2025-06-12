using Ardalis.Result;
using ChronoQuest.Core.Domain.Stats;

namespace ChronoQuest.Core.Domain.Base;

public class Question : Entity
{
    private Question() { }
    public Question(
        Topic topic, 
        Difficulty difficulty, 
        string content, 
        Option correctOption,
        List<Option> otherOptions, 
        int number,
        QuestionType type)
    {
        Topic = topic;
        Difficulty = difficulty;
        Content = content;
        Options = [correctOption, ..otherOptions];
        CorrectOptionId = correctOption.Id;
        Number = number;
        Type = type;
    }

    public Topic Topic { get; private set; } = null!;
    public Difficulty Difficulty { get; private set; }
    public string Content { get; private set; } = null!;
    public List<Option> Options { get; private set; } = null!;
    public Guid CorrectOptionId { get; private set; }
    public int Number { get; private init; }
    public QuestionType Type { get; private init; }

    public Guid? ChapterId { get; private set; }
    
    public List<QuestionAnswer> Answers { get; private init; } = [];

    public List<QuestionReadingTime> ReadingTime { get; private init; } = [];

    public QuestionStatus Status => MostRecentAnswer() switch
    {
        { IsCorrect: true } => QuestionStatus.Correct,
        { IsCorrect: false } => QuestionStatus.Wrong,
        _ => QuestionStatus.Unanswered
     };

    public Result<QuestionAnswer> Answer(Guid userId, Guid optionId)
    {
        if (Options.All(o => o.Id != optionId))
        {
            return Result.Invalid(new ValidationError($"Question {Id} does not have option {optionId}"));
        }

        var answer = new QuestionAnswer(
            userId: userId,
            questionId: Id,
            optionId: optionId,
            answeredOn: DateTime.UtcNow,
            isCorrect: optionId == CorrectOptionId);
        
        Answers.Add(answer);

        return answer;
    }

    public QuestionAnswer? MostRecentAnswer() => Answers.LastOrDefault();
}