using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Identity.Filters;
public class RoleFilter : PaginationFilter
{
    public RoleFilter(int page, int pageSize) : base(page, pageSize)
    {
    }

    public string Title { get; set; }
    public int[] PermissionIds { get; set; }
    public RoleIncludes Include { get; set; }
    public RoleSortBy? SortBy { get; set; }
}

public class RoleIncludes
{
    public bool Permission { get; set; }
    public bool UserRole { get; set; }
}


public enum RoleSortBy
{
    CreationDate = 10,
    CreationDateDescending = 11,
}