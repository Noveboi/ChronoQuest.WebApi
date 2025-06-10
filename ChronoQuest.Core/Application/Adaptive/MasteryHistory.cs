using ChronoQuest.Core.Domain.AdaptiveLearning;
using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Core.Application.Adaptive;

public sealed record MasteryHistory(Topic Topic, IEnumerable<UserSkillMastery> History);