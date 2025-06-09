using ChronoQuest.Core.Domain.Base;

namespace ChronoQuest.Endpoints.Quiz.Dto;

internal sealed record QuestionDto(string Content, List<Option> Options);