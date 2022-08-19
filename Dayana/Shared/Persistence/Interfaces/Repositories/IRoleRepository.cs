using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Persistence.Models.Filters.Roles;

namespace Dayana.Shared.Persistence.Interfaces.Repositories;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role> GetRoleByIdAsync(int id);
    Task<List<Role>> GetRolesByIdsAsync(IEnumerable<int> ids);
    Task<List<Role>> GetRolesByFilterAsync(RoleFilter filter);
    Task<int> CountRolesByFilterAsync(RoleFilter filter);
}