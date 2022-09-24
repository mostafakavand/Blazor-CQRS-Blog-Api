using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.IdentityRepositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByUsernameAsync(string username);
    Task<int> CountUsersByFilterAsync(CustomaizedPaginationFilter<List<UserState>?, UserSortBy?, string, string> filter);
    Task<List<User>> GetUsersByIdsAsync(IEnumerable<int> ids);
    Task<List<User>> GetUsersByFilterAsync(CustomaizedPaginationFilter<List<UserState>?, UserSortBy?, string, string> filter);
}