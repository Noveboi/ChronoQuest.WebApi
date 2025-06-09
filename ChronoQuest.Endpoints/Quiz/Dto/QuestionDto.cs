using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Endpoints.Quiz.Dto;

internal sealed record QuestionDto(
    Guid Id, 
    int Number, 
    string Content,
    string Topic,
    string Status,
    string Type,
    List<Option> Options);