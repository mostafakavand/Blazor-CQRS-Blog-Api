using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;

namespace Dayana.Shared.Persistence.Models.Identity.Filters;

public record PermissionFilter : PaginationFilter
{
    public PermissionFilter(int page, int pageSize) : base(page, pageSize)
    {
    }

    public int? RoleId { get; set; }
    public string? Value { get; set; }
    public string? Title { get; set; }
    public string? Name { get; set; }
    public SortByEnum? SortByEnum { get; set; }
}