using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Endpoints.Questions.Dto;

internal sealed record QuestionDto(
    Guid Id, 
    string Content,
    TopicDto Topic,
    string Type,
    IEnumerable<OptionDto> Options,
    Guid? AnsweredOptionId,
    Guid? CorrectOptionId);