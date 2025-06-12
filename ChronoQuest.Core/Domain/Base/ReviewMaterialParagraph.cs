namespace ChronoQuest.Core.Domain.Base;

/// <summary>
/// Contains a paragraph or a snippet of text for extra material.
/// </summary>
public sealed class ReviewMaterialParagraph : Entity
{
    public Topic Topic { get; init; } = null!;
    public string Content { get; init; } = null!;
}