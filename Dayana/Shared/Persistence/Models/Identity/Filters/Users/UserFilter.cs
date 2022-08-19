using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Identity.Filters.Users;

public class UserFilter : PaginationFilter
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