﻿using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Identity.Base;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.IdentityRepositories;

public interface IRoleRepository : IRepository<Role, RoleModel>
{
    Task<Role> GetRoleByIdAsync(int id);
    Task<List<Role>> GetRolesByIdsAsync(IEnumerable<int> ids);
    Task<List<Role>> GetRolesByFilterAsync(DefaultPaginationFilter filter);
    Task<int> CountRolesByFilterAsync(DefaultPaginationFilter filter);
}