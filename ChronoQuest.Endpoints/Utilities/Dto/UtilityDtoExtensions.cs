using ChronoQuest.Core.Domain;

namespace ChronoQuest.Endpoints.Utilities.Dto;

internal static class UtilityDtoExtensions
{
    public static UserMarkerDto ToDto(this UserMarker? marker) =>
        marker is null
            ? new UserMarkerDto(null, null, null, null)
            : new UserMarkerDto(
                ChapterId: marker.ChapterId, 
                QuestionId: marker.QuestionId, 
                ExamId: marker.ExamId,
                ReviewId: marker.ReviewId);
}