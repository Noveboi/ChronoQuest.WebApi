namespace ChronoQuest.Core.Domain;

public class Question : Entity
{
    public Difficulty Difficulty { get; private set; }
    public string Content { get; private set; }
    public List<Option> Options { get; private set; }

    public Question(Guid id, Difficulty difficulty, string content, List<Option> options) : base(id)
    {
        Difficulty = difficulty;
        Content = content;
        Options = options;
    }
}