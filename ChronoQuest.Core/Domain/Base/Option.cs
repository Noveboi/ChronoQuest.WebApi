namespace ChronoQuest.Core.Domain.Base;

public sealed class Option : Entity
{
    private Option() { }
    public Option(string content, Guid? id = null) : base(id)
    {
        Content = content;
    }

    public string Content { get; private set; } = null!;
}