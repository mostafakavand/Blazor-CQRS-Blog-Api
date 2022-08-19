using Dayana.Shared.Domains.Identity.Claims;
using Dayana.Shared.Persistence.Models.Identity.Filters.Claims;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.IdentityRepositories;

public interface IClaimRepository : IRepository<Claim>
{
    Task<Claim> GetClaimByIdAsync(int id);
    Task<List<Claim>> GetClaimsByIdsAsync(IEnumerable<int> ids);
    Task<List<Claim>> GetClaimsByFilterAsync(ClaimFilter filter);
    Task<int> CountClaimsByFilterAsync(ClaimFilter filter);
}