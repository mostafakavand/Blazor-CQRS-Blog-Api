using Dayana.Shared.Domains.Identity.Permissions;
using Dayana.Shared.Persistence.Models.Filters.Permissions;

namespace Dayana.Shared.Persistence.Interfaces.Repositories;

public interface IPermissionRepository : IRepository<Permission>
{
    Task<Permission> GetPermissionByIdAsync(int id);
    Task<List<Permission>> GetPermissionsByIdsAsync(IEnumerable<int> ids);
    Task<List<Permission>> GetPermissionsByFilterAsync(PermissionFilter filter);
    Task<int> CountPermissionsByFilterAsync(PermissionFilter filter);
}