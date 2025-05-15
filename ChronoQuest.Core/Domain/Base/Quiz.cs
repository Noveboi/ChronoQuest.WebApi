namespace ChronoQuest.Core.Domain.Base;

public class Quiz : Entity
{
    private Quiz() { }
    public Quiz(List<Question> questions, Guid? id = null) : base(id)
    {
        Questions = questions;
    }
    
    public List<Question> Questions { get; private set; } = null!;
}