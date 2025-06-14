namespace ChronoQuest.Core.Domain;

/// <summary>
/// Refers to various entities the user could be interacting with
/// </summary>
public enum UserIs
{
    ReadingChapter = 0,
    AnsweringQuestion = 1,
    TakingExam = 2,
    ReviewingMaterial = 3,
    Done = 4,
}