using ChronoQuest.Core.Domain;
using ChronoQuest.Core.Infrastructure.Workers;

namespace ChronoQuest.Core.Application;

public interface IMarkerService
{
    Task UpsertAsync(UpdateUserMarkerRequest request, CancellationToken token);
    Task<UserMarker?> GetAsync(Guid userId, CancellationToken token);
}