using ChronoQuest.Core.Domain;

namespace ChronoQuest.AdaptiveLearning.Model;

internal sealed class BayesianKnowledgeTracingModel(
    Guid learningModelId,
    Guid skillId,
    Probability pInit,
    Probability pLearn,
    Probability pSlip,
    Probability pGuess) : Entity
{
    public Guid LearningModelId { get; private init; } = learningModelId;
    public Guid SkillId { get; private init;  } = skillId;
    
    // p_init
    public Probability InitialKnowledgeProbability { get; private set; } = pInit;

    // p_learn
    public Probability LearningProbability { get; private set; } = pLearn;

    // p_slip
    public Probability SlipProbability { get; private set; } = pSlip;

    // p_guess
    public Probability GuessProbability { get; private set; } = pGuess;

    private readonly List<UserSkillMastery> _masteryHistory = [];
    public IReadOnlyCollection<UserSkillMastery> MasteryHistory => _masteryHistory;

    public Probability CurrentProbabilityOfMastery => 
        _masteryHistory.MaxBy(x => x.UtcDateTime)?.ProbabilityOfMastery ?? InitialKnowledgeProbability;

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
    
    public void Update(bool isCorrect) => _masteryHistory.Add(new UserSkillMastery(
        modelId: Id, 
        dateTime: DateTimeOffset.UtcNow, 
        probabilityOfMastery: GetNextProbabilityOfMastery(isCorrect)));

    public Probability Predict(bool isCorrect)
    {
        var next = GetNextProbabilityOfMastery(isCorrect);
        return next * (1 - SlipProbability) + (1 - next) * GuessProbability;
    }

    private static Probability Divide(Probability a, Probability b, Probability currentMastery) => 
        b.Value == 0 ? currentMastery : new Probability(a.Value / b.Value);
}