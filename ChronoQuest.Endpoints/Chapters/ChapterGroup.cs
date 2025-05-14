using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters;

internal sealed class ChapterGroup : Group
{
    public ChapterGroup() => Configure("/chapters", _ => { });
}