namespace ChronoQuest.Core.Domain;

public class Exam :  Entity
{
    public Guid UserId { get; private set; }
    public List<Question> Questions { get; private set; }
    public TimeSpan TimeLimit { get; private set; }

    public Exam(Guid id, Guid userId, List<Question> questions, TimeSpan timeLimit) : base(id)
    {
        UserId = userId;
        Questions = questions;
        TimeLimit = timeLimit;
    }
}