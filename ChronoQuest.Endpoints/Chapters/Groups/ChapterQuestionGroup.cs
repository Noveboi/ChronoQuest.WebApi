using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters.Groups;

internal sealed class ChapterQuestionGroup : SubGroup<ChapterGroup>
{
    public ChapterQuestionGroup() => Configure("{chapterId:guid}/questions", _ => { });
}