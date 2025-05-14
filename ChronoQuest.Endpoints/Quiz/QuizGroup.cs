using ChronoQuest.Endpoints.Chapters;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Quiz;

internal sealed class QuizGroup : SubGroup<ChapterGroup>
{
    // We don't need to specify a Quiz ID here because there is one quiz per chapter.
    public QuizGroup() => Configure("{chapterId:guid}/quiz", _ => { });
}