namespace ChronoQuest.Endpoints.Questions.Dto;

internal sealed record QuestionStatsForTopicDto(TopicDto Topic, double CorrectAnswersPercentage, double AverageAnswerTimeInSeconds);