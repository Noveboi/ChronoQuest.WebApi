using ChronoQuest.Core.Domain;

namespace ChronoQuest.Core.Application.Markers;

public interface IMarkerService
{
    Task UpsertAsync(UpdateUserMarkerRequest request, CancellationToken token);
    Task<UserMarker?> GetAsync(Guid userId, CancellationToken token);
}