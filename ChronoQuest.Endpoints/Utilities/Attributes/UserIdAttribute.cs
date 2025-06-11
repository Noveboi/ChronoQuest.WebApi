using System.Security.Claims;
using FastEndpoints;

namespace ChronoQuest.Endpoints.Utilities.Attributes;

public sealed class UserIdAttribute() : FromClaimAttribute(claimType: ClaimTypes.NameIdentifier)
{
    
}