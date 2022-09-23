using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Identity.Filters;
public record UserFilter : PaginationFilter
{
    protected UserFilter(int page, int pageSize) : base(page, pageSize)
    {

    }

    public string Keyword { get; set; }
    public string Email { get; set; }
    public List<UserState> States { get; set; }

    public UserIncludes Include { get; set; }
    public UserSortBy? SortBy { get; set; }
}


public class UserIncludes
{
    public bool Role { get; set; }
}


public enum UserSortBy
{
    CreationDate = 1,
    CreationDateDescending = 2,

    LastLoginDate = 28,
    LastLoginDateDescending = 29,
}