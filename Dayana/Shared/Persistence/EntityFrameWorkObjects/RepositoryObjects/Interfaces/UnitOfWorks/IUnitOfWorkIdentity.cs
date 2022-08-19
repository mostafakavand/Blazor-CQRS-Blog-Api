using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.IdentityRepositories;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;

public interface IUnitOfWorkIdentity : IDisposable
{
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    IClaimRepository Claims { get; }
    IPermissionRepository Permissions { get; }

    Task<bool> CommitAsync();
}