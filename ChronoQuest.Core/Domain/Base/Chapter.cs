namespace ChronoQuest.Core.Domain.Base;

public class Chapter : Entity
{
    private Chapter() { }
    public Chapter(string title, string content, Quiz quiz, Guid? id = null) : base(id)
    {
        Title = title;
        Content = content;
        Quiz = quiz;
    }

    public string Title { get; private set; } = null!;
    public string Content { get; private set; } = null!;
    public Quiz Quiz { get; private set; } = null!;
}