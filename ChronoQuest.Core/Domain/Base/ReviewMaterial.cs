namespace ChronoQuest.Core.Domain.Base;

public sealed class ReviewMaterial : Entity
{
    private ReviewMaterial() { }
    public ReviewMaterial(Guid userId, string content)
    {
        UserId = userId;
        Content = content;
    }

    public Guid UserId { get; private set; }
    public string Content { get; private set; } = null!;
}