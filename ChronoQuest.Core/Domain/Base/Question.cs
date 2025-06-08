using Ardalis.Result;
using ChronoQuest.Core.Domain.Stats;

namespace ChronoQuest.Core.Domain.Base;

public class Question : Entity
{
    private Question() { }
    public Question(Topic topic, Difficulty difficulty, string content, List<Option> options, Guid correctOptionId, Guid? id = null) : base(id)
    {
        Topic = topic;
        Difficulty = difficulty;
        Content = content;
        Options = options;
        CorrectOptionId = correctOptionId;
    }

    public Topic Topic { get; private set; } = null!;
    public Difficulty Difficulty { get; private set; }
    public string Content { get; private set; } = null!;
    public List<Option> Options { get; private set; } = null!;
    public Guid CorrectOptionId { get; private set; }

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

        return answer;
    }
}