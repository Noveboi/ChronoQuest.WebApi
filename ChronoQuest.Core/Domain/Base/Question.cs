namespace ChronoQuest.Core.Domain.Base;

public class Question : Entity
{
    private Question() { }
    public Question(Topic topic, Difficulty difficulty, string content, List<Option> options, Guid correctOptionId, Guid? id = null) : base(id)
    {
        Topic = topic;
        Difficulty = difficulty;
        Content = content;
        Options = options;
        CorrectOptionId = correctOptionId;
    }

    public Topic Topic { get; private set; } = null!;
    public Difficulty Difficulty { get; private set; }
    public string Content { get; private set; } = null!;
    public List<Option> Options { get; private set; } = null!;
    public Guid CorrectOptionId { get; private set; }
}