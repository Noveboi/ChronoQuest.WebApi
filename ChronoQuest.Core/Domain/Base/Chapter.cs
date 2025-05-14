namespace ChronoQuest.Core.Domain;

public class Chapter : Entity
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public Quiz Quiz { get; private set; }

    public Chapter(Guid id, string title, string content, Quiz quiz) : base(id)
    {
        Title = title;
        Content = content;
        Quiz = quiz;
    }
}