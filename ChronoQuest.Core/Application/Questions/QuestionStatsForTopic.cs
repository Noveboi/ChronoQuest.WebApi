using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Application.Questions;

public sealed record QuestionStatsForTopic(Topic Topic, double CorrectAnswersPercentage, TimeSpan AverageAnswerTime);