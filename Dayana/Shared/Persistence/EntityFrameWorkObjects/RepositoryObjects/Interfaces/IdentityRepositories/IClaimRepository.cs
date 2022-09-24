using Dayana.Shared.Domains.Identity.Claims;
using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.IdentityRepositories;

public interface IClaimRepository : IRepository<Claim>
{
    Task<Claim> GetClaimByIdAsync(int id);
    Task<List<Claim>> GetClaimsByIdsAsync(IEnumerable<int> ids);
    Task<List<Claim>> GetClaimsByFilterAsync(DefaultPaginationFilter filter);
    Task<int> CountClaimsByFilterAsync(DefaultPaginationFilter filter);
}