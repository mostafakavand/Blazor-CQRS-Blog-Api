using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Identity.Filters;

namespace Dayana.Shared.Persistence.Models.Identity.Requests.Roles;

public class GetRolesByFilterRequest : PaginationFilter
{
    protected GetRolesByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }
    public GetRolesByFilterRequest()
    {
    }

    public string? Title { get; set; }
    public List<string>? PermissionEids { get; set; }
    public RoleSortBy? SortBy { get; set; }
}