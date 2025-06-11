using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Application.Chapters;

public sealed record ChapterStats(Dictionary<Chapter, StatsPerChapter> Chapters);