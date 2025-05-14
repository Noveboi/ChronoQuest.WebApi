using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Domain;

public class Question(Difficulty difficulty, string content, List<Option> options, Guid? id = null) : Entity(id)
{
    public Difficulty Difficulty { get; private set; } = difficulty;
    public string Content { get; private set; } = content;
    public List<Option> Options { get; private set; } = options;
}