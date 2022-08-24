using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Identity.Requests.Permissions;

public class GetPermissionsByFilterRequest : PaginationFilter
{
    protected GetPermissionsByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }
    public GetPermissionsByFilterRequest()
    {
    }

    public string? RoleEid { get; set; }
    public string? Value { get; set; }
    public string? Title { get; set; }
    public string? Name { get; set; }
}