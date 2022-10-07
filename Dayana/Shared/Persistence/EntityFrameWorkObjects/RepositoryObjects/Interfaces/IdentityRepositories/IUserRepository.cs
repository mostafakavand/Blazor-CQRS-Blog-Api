using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;
using Dayana.Shared.Persistence.Models.Identity.Base;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.IdentityRepositories;

public interface IUserRepository : IRepository<User, UserModel>
{
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByUsernameAsync(string username);
    Task<int> CountUsersByFilterAsync(CustomaizedPaginationFilterTwo<List<UserState>?, UserSortBy?> filter);
    Task<List<User>> GetUsersByIdsAsync(IEnumerable<int> ids);
    Task<List<User>> GetUsersByFilterAsync(CustomaizedPaginationFilterTwo<List<UserState>?, UserSortBy?> filter);
}