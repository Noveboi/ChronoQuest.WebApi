namespace ChronoQuest.Core.Application.Adaptive;

public interface IAdaptiveLearning
{
    Task UpdateKnowledgeAsync(UpdateLearningModelRequest request, CancellationToken token);
    Task<IEnumerable<MasteryHistory>> GetMasteryOverTimeAsync(Guid userId, CancellationToken token);
    Task<IEnumerable<UserPerformanceForTopic>> GetPerformanceAsync(Guid userId, CancellationToken token);
}