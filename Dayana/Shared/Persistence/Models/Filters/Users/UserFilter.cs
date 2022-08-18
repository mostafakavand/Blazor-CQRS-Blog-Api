using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Domains.Identity.Users;

namespace Dayana.Shared.Persistence.Models.Filters.Users;

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