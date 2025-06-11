using ChronoQuest.Core.Domain.Stats;

namespace ChronoQuest.Core.Domain.Base;

public class Chapter : Entity
{
    private Chapter() { }
    public Chapter(int order, Topic topic, string title, string content, List<Question> questions)
    {
        Order = order;
        Topic = topic;
        Title = title;
        Content = content;
        Questions = questions;
    }

    /// <summary>
    /// Used to sort chapters in ascending order.
    /// </summary>
    public int Order { get; private set; }  
    public Topic Topic { get; private set; } = null!;
    public string Title { get; private set; } = null!;
    public string Content { get; private set; } = null!;

    public List<Question> Questions { get; private init; } = null!;
    public List<ChapterReadingTime> Readings { get; private init; } = null!;
}