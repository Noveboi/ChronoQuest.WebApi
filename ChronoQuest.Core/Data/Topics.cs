using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Data;

internal static class Topics
{
    public static readonly Topic Geography = new("Geography");
    public static readonly Topic History = new("History");
    public static readonly Topic Culture = new("Culture");

    public static IEnumerable<Topic> All => [Geography, History, Culture];
}