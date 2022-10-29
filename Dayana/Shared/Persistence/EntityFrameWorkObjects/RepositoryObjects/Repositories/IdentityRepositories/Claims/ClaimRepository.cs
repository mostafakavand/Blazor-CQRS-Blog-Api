using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Domains.Identity.Claims;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.IdentityRepositories;
using Dayana.Shared.Persistence.Extensions.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Repositories.IdentityRepositories.Claims;

public class ClaimRepository : Repository<Claim>, IClaimRepository
{
    private readonly IQueryable<Claim> _queryable;

    public ClaimRepository(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<Claim>();
    }

    public async Task<Claim> GetClaimByIdAsync(int id)
    {
        return await _queryable
            .SingleOrDefaultAsync(x => x.Id == id) ?? new Claim();
    }

    public async Task<List<Claim>> GetClaimsByIdsAsync(IEnumerable<int> ids)
    {
        var query = _queryable;

        query = query.AsNoTracking();

        // Filter by ids
        if (ids?.Any() == true)
            query = query.Where(x => ids.Contains(x.Id));

        return await query.ToListAsync();
    }

    public async Task<List<Claim>> GetClaimsByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable;

        query = query.AsNoTracking();

        query = query.ApplyFilter(filter);
        query = query.ApplySort(filter.SortBy);

        return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
    }

    public async Task<int> CountClaimsByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable;

        query = query.AsNoTracking();

        query = query.ApplyFilter(filter);

        return await query.CountAsync();
    }
}