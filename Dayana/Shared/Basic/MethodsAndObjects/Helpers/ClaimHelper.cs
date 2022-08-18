using Dayana.Shared.Domains.Identity.Claims;
using Dayana.Shared.Persistence.Models.Commands.Users;

namespace Dayana.Shared.Basic.MethodsAndObjects.Helpers;

public static class ClaimHelper
{
    public static Claim CreateClaim(CreateUserPermissionCommand command) => new Claim
    {
        Value = command.PermissionId.ToString(),
        UserId = command.UserId,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
    };

}