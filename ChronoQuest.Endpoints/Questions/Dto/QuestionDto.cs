using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Endpoints.Questions.Dto;

internal sealed record QuestionDto(
    Guid Id, 
    int Number, 
    string Content,
    TopicDto Topic,
    string Type,
    IEnumerable<OptionDto> Options,
    Guid? AnsweredOptionId,
    Guid? CorrectOptionId);