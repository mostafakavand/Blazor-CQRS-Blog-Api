using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Identity.Filters;

namespace Dayana.Shared.Persistence.Models.Identity.Requests.Users;

public class GetUserByFilterRequest : PaginationFilter
{
    protected GetUserByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }

    public GetUserByFilterRequest()
    {
    }

    public string? Keyword { get; set; }
    public string? Email { get; set; }
    public List<UserState>? States { get; set; }
    public UserSortBy? SortBy { get; set; }
}