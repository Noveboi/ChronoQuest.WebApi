using ChronoQuest.Core.Domain.AdaptiveLearning.Metrics;
using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Application.Adaptive;

public sealed record UserPerformanceForTopic(UserPerformance Performance, Topic Topic);