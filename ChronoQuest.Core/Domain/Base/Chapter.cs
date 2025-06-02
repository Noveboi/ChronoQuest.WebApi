namespace ChronoQuest.Core.Domain.Base;

public class Chapter : Entity
{
    private Chapter() { }
    public Chapter(int order, Topic topic, string title, string content, Quiz quiz, Guid? id = null) : base(id)
    {
        Order = order;
        Topic = topic;
        Title = title;
        Content = content;
        Quiz = quiz;
    }

    /// <summary>
    /// Used to sort chapters in ascending order.
    /// </summary>
    public int Order { get; private set; }  
    public Topic Topic { get; private set; } = null!;
    public string Title { get; private set; } = null!;
    public string Content { get; private set; } = null!;
    public Quiz Quiz { get; private set; } = null!;
}