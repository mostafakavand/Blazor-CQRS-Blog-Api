using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Identity.Filters.Permissions;

public class PermissionFilter : PaginationFilter
{
    public PermissionFilter(int page, int pageSize) : base(page, pageSize)
    {
    }

    public int? RoleId { get; set; }
    public string? Value { get; set; }
    public string? Title { get; set; }
    public string? Name { get; set; }
}