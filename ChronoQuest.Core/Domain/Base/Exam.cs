namespace ChronoQuest.Core.Domain.Base;

public class Exam : Entity
{
    private Exam() { }
    public Exam(Guid userId, List<Question> questions, TimeSpan timeLimit, Guid? id = null) : base(id)
    {
        UserId = userId;
        Questions = questions;
        TimeLimit = timeLimit;
    }

    public Guid UserId { get; private set; }
    public List<Question> Questions { get; private set; } = null!;
    public TimeSpan TimeLimit { get; private set; }
}