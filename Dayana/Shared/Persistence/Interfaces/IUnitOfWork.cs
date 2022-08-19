using Dayana.Shared.Persistence.Interfaces.Repositories;

namespace Dayana.Shared.Persistence.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    IClaimRepository Claims { get; }
    IPermissionRepository Permissions { get; }

    Task<bool> CommitAsync();
}