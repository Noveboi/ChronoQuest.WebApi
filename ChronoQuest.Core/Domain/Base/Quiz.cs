namespace ChronoQuest.Core.Domain;

public class Quiz : Entity
{
    public List<Question> Questions { get; private set; }

    public Quiz(Guid id, List<Question> questions) : base(id)
    {
        Questions = questions;
    }
}