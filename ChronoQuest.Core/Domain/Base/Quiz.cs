namespace ChronoQuest.Core.Domain;

public class Quiz(List<Question> questions, Guid? id = null) : Entity(id)
{
    public List<Question> Questions { get; private set; } = questions;
}