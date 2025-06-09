using FastEndpoints;

namespace ChronoQuest.Endpoints.Chapters.Groups;

internal sealed class ChapterGroup : Group
{
    public ChapterGroup() => Configure("/chapters", _ => { });
}