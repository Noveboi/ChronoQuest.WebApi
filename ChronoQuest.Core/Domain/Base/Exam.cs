namespace ChronoQuest.Core.Domain.Base;

public class Exam(Guid userId, List<Question> questions, TimeSpan timeLimit, Guid? id = null) :  Entity(id)
{
    public Guid UserId { get; private set; } = userId;
    public List<Question> Questions { get; private set; } = questions;
    public TimeSpan TimeLimit { get; private set; } = timeLimit;
}