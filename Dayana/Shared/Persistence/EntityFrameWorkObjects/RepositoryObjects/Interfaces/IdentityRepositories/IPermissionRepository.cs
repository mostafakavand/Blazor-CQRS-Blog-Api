using Dayana.Shared.Domains.Identity.Permissions;
using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.IdentityRepositories;

public interface IPermissionRepository : IRepository<Permission>
{
    Task<Permission> GetPermissionByIdAsync(int id);
    Task<List<Permission>> GetPermissionsByIdsAsync(IEnumerable<int> ids);
    Task<List<Permission>> GetPermissionsByFilterAsync(DefaultPaginationFilter filter);
    Task<int> CountPermissionsByFilterAsync(DefaultPaginationFilter filter);
}