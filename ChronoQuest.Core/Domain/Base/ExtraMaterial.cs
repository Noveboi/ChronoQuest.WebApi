namespace ChronoQuest.Core.Domain.Base;

public class ExtraMaterial : Entity
{
    private ExtraMaterial() { }
    public ExtraMaterial(Guid userId, string content)
    {
        UserId = userId;
        Content = content;
    }

    public Guid UserId { get; private set; }
    public string Content { get; private set; } = null!;
}