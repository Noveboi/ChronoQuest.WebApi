using System.Diagnostics.CodeAnalysis;

namespace ChronoQuest.Endpoints.Utilities.Dto;

internal sealed record UserMarkerDto(Guid? ChapterId, Guid? QuestionId, Guid? ExamId, Guid? ReviewId);