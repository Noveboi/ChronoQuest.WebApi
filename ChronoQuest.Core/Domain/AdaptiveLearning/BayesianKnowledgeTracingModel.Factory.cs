namespace ChronoQuest.Core.Domain.AdaptiveLearning;

internal partial class BayesianKnowledgeTracingModel
{
    public static BayesianKnowledgeTracingModel CreateWithDefaultParameters(Guid userId, Guid topicId)
    {
        return new BayesianKnowledgeTracingModel(
            userId: userId,
            topicId: topicId,
            pInit: 0.2,
            pLearn: 0.075,
            pSlip: 0.075,
            pGuess: 0.35);
    }
}