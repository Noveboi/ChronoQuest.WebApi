using ChronoQuest.Core.Data.Chapters;
using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Data;

internal static class AllChapters
{
    public static IEnumerable<Chapter> Get()
    {
        yield return HistoryChapter.Chapter;
        yield return GeographyChapter.Chapter;
        yield return CultureChapter.Chapter;
    }
}