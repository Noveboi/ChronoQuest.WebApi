using ChronoQuest.Endpoints.Questions.Dto;

namespace ChronoQuest.Endpoints.AdaptiveLearning.Dto;

internal sealed record UserPerformanceForTopicDto(
    double Score,
    string State,
    TopicDto Topic);