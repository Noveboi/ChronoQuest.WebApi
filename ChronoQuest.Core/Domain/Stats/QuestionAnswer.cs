namespace ChronoQuest.Core.Domain.Stats;

public class QuestionAnswer : Entity
{
    private QuestionAnswer() { }
    public QuestionAnswer(Guid userId, Guid questionId, Guid optionId, DateTime answeredOn, bool isCorrect)
    {
        UserId = userId;
        QuestionId = questionId;
        OptionId = optionId;
        AnsweredOn = answeredOn;
        IsCorrect = isCorrect;
    }

    public Guid UserId { get; private set; }
    public Guid QuestionId { get; private set; }
    public Guid OptionId { get; private set; }
    public DateTime AnsweredOn { get; private set; }
    public bool IsCorrect { get; private set; }
}