namespace ChronoQuest.Core.Domain.Base;

public class ExtraMaterial : Entity
{
    private ExtraMaterial() { }
    public ExtraMaterial(User user, string content)
    {
        User = user;
        Content = content;
    }
    
    public User User { get; private set; } = null!;
    public string Content { get; private set; } = null!;
}