namespace ChronoQuest.Core.Domain.Base;

public enum QuestionType
{
    Regular = 0,
    /// <summary>
    /// A question that can be skipped for advanced users.
    /// </summary>
    Skippable = 1
}