using ChronoQuest.Endpoints.Questions.Dto;

namespace ChronoQuest.Endpoints.AdaptiveLearning.Dto;

public sealed record UserMasteryHistoryDto(TopicDto Topic, IEnumerable<UserMasteryDto> History);