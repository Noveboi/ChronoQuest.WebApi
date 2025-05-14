namespace ChronoQuest.Core.Domain;

public class Quiz : Entity
{
    public Guid ChapterId { get; private set; }
    public List<Question> Questions { get; private set; }
}