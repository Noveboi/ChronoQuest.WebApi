using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Endpoints.Questions.Dto;

internal sealed record QuestionDto(
    Guid Id, 
    int Number, 
    string Content,
    string Topic,
    string Status,
    string Type,
    List<Option> Options);