namespace ChronoQuest.Core.Domain;

public class Chapter : Entity
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public Quiz Quiz { get; private set; }
}