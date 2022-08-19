using Dayana.Shared.Persistence.Interfaces.IdentityRepositories;

namespace Dayana.Shared.Persistence.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    IClaimRepository Claims { get; }
    IPermissionRepository Permissions { get; }

    Task<bool> CommitAsync();
}