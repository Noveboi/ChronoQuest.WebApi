namespace ChronoQuest.Core.Domain;

public class Question : Entity
{
    public Difficulty Difficulty { get; private set; }
    public string Content { get; private set; }
    public List<Option> Options { get; private set; }
}