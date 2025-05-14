namespace ChronoQuest.Core.Domain.Base;

public class Chapter(string title, string content, Quiz quiz, Guid? id = null) : Entity(id)
{
    public string Title { get; private set; } = title;
    public string Content { get; private set; } = content;
    public Quiz Quiz { get; private set; } = quiz;
}