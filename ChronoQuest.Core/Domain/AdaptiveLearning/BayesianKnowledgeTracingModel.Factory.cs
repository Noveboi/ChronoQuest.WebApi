namespace ChronoQuest.Core.Domain.AdaptiveLearning;

internal partial class BayesianKnowledgeTracingModel
{
    public static BayesianKnowledgeTracingModel CreateWithDefaultParameters(Guid userId, Guid topicId)
    {
        return new BayesianKnowledgeTracingModel(
            userId: userId,
            topicId: topicId,
            pInit: 0.3,
            pLearn: 0.1,
            pSlip: 0.1,
            pGuess: 0.225);
    }
}