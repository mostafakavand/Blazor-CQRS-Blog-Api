using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Domains.Identity.Permissions;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.IdentityRepositories;
using Dayana.Shared.Persistence.Extensions.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Repositories.IdentityRepositories.Permissions;

public class PermissionRepository : Repository<Permission>, IPermissionRepository
{
    private readonly IQueryable<Permission> _queryable;

    public PermissionRepository(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<Permission>();
    }

    public async Task<Permission> GetPermissionByIdAsync(int id)
    {
        return await _queryable
            .Include(x => x.Roles)
            .SingleOrDefaultAsync(x => x.Id == id) ?? new Permission();
    }

    public async Task<List<Permission>> GetPermissionsByIdsAsync(IEnumerable<int> ids)
    {
        var query = _queryable;

        query = query.AsNoTracking()
            .Include(x => x.Roles);

        // Filter by ids
        if (ids?.Any() == true)
            query = query.Where(x => ids.Contains(x.Id));

        return await query.ToListAsync();
    }

    public async Task<List<Permission>> GetPermissionsByFilterAsync(DefaultPaginationFilter filter)
    {
        try
        {
            var query = _queryable;

            query = query.AsNoTracking()
                .Include(x => x.Roles);

            query = query.ApplyFilter(filter);
            query = query.ApplySort();

            return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<int> CountPermissionsByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable;

        query = query.AsNoTracking()
            .Include(x => x.Roles);

        query = query.ApplyFilter(filter);

        return await query.CountAsync();
    }
}