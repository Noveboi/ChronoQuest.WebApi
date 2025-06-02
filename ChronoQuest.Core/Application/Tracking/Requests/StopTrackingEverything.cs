using MediatR;

namespace ChronoQuest.Core.Application.Tracking.Requests;

public sealed record StopTrackingEverything(Guid UserId) : INotification;