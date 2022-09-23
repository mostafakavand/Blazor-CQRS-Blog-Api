using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;

namespace Dayana.Shared.Persistence.Models.Identity.Filters;
public record RoleFilter : PaginationFilter
{
    public RoleFilter(int page, int pageSize) : base(page, pageSize)
    {
    }

    public string Title { get; set; }
    public int[] PermissionIds { get; set; }
    public RoleIncludes Include { get; set; }
    public SortByEnum? SortBy { get; set; }
}

public class RoleIncludes
{
    public bool Permission { get; set; }
    public bool UserRole { get; set; }
}