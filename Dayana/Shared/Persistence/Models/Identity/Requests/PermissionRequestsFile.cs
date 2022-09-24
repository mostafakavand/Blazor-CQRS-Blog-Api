using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Identity.Requests;
public record GetPermissionsByFilterRequest : DefaultPaginationFilter
{
    protected GetPermissionsByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }
    public GetPermissionsByFilterRequest()
    {
    }

    public string? RoleEid { get; init; }
}