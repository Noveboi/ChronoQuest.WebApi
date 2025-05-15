namespace ChronoQuest.Core.Domain.Base;

public class Question : Entity
{
    private Question() { }
    public Question(Difficulty difficulty, string content, List<Option> options, Guid? id = null) : base(id)
    {
        Difficulty = difficulty;
        Content = content;
        Options = options;
    }

    public Difficulty Difficulty { get; private set; } 
    public string Content { get; private set; } = null!;
    public List<Option> Options { get; private set; } = null!;
}