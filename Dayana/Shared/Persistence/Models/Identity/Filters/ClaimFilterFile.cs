using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Identity.Filters;

public class ClaimFilter : PaginationFilter
{
    protected ClaimFilter(int page, int pageSize) : base(page, pageSize)
    {
    }

    public int? UserId { get; set; }
    public string? Value { get; set; }
    public ClaimSortBy? SortBy { get; set; }
}


public enum ClaimSortBy
{
    CreationDate = 10,
    CreationDateDescending = 11,
}