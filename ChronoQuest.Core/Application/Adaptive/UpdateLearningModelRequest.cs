namespace ChronoQuest.Core.Application.Adaptive;

public sealed record UpdateLearningModelRequest(Guid UserId, Guid TopicId, bool IsPositive);
