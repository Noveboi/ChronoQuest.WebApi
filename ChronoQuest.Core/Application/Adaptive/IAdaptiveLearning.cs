namespace ChronoQuest.Core.Application.Adaptive;

public interface IAdaptiveLearning
{
    Task UpdateKnowledgeAsync(Guid userId, Guid topicId, bool isPositive);
}