namespace ChronoQuest.Core.Domain;

public class Quiz : Entity
{
    public List<Question> Questions { get; private set; }
}