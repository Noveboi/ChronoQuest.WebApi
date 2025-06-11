
namespace ChronoQuest.Core.Domain.AdaptiveLearning;

internal sealed partial class BayesianKnowledgeTracingModel : Entity
{
    public Guid UserId { get; private init; }
    public Guid TopicId { get; private init; }
    
    // p_init
    public Probability InitialKnowledgeProbability { get; private init; } = null!;

    // p_learn
    public Probability LearningProbability { get; private init; } = null!;

    // p_slip
    public Probability SlipProbability { get; private init; } = null!;

    // p_guess
    public Probability GuessProbability { get; private init; } = null!;
    
    private readonly List<UserSkillMastery> _masteryHistory = [];
    public IReadOnlyCollection<UserSkillMastery> MasteryHistory => _masteryHistory;
    
    private BayesianKnowledgeTracingModel() { }
    private BayesianKnowledgeTracingModel(
        Guid userId,
        Guid topicId,
        Probability pInit,
        Probability pLearn,
        Probability pSlip,
        Probability pGuess)
    {
        UserId = userId;
        TopicId = topicId;
        InitialKnowledgeProbability = pInit;
        LearningProbability = pLearn;
        SlipProbability = pSlip;
        GuessProbability = pGuess;
    }

    public Probability CurrentProbabilityOfMastery => 
        _masteryHistory.MaxBy(x => x.UtcDateTime)?.ProbabilityOfMastery ?? InitialKnowledgeProbability;
    
    public void Update(bool isCorrect)
    {
        _masteryHistory.Add(new UserSkillMastery(
            modelId: Id,
            dateTime: DateTimeOffset.UtcNow,
            probabilityOfMastery: GetNextProbabilityOfMastery(isCorrect)));
    }

    public Probability Predict(bool isCorrect)
    {
        var next = GetNextProbabilityOfMastery(isCorrect);
        return next * (1 - SlipProbability) + (1 - next) * GuessProbability;
    }
    
    private Probability GetNextProbabilityOfMastery(bool isCorrect)
    {
        var current = CurrentProbabilityOfMastery;
        
        var numerator = isCorrect 
            ? current * (1 - SlipProbability)
            : current * SlipProbability;

        var denominator = isCorrect
            ? current * (1 - SlipProbability) + (1 - current) * GuessProbability
            : current * SlipProbability + (1 - current) * (1 - GuessProbability);

        var observation = Divide(numerator, denominator, current);

        return observation + (1 - observation) * LearningProbability;
    }

    private static Probability Divide(Probability a, Probability b, Probability currentMastery) => 
        b.Value == 0 ? currentMastery : new Probability(a.Value / b.Value);
}