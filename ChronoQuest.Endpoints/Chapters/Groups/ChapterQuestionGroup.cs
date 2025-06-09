using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters.Groups;

internal sealed class ChapterQuestionGroup : SubGroup<ChapterGroup>
{
    // We don't need to specify a Quiz ID here because there is one quiz per chapter.
    public ChapterQuestionGroup() => Configure("{chapterId:guid}/quiz", _ => { });
}