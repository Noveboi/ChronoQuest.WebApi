namespace ChronoQuest.Core.Domain.Base;

public sealed class Option(string content, Guid? id = null) : Entity(id)
{
    public string Content { get; private set; } = content;
}