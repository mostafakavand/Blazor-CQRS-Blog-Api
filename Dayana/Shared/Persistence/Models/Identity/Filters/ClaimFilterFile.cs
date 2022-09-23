using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;

namespace Dayana.Shared.Persistence.Models.Identity.Filters;

public record ClaimFilter : PaginationFilter
{
    protected ClaimFilter(int page, int pageSize) : base(page, pageSize)
    {
    }

    public int? UserId { get; set; }
    public string? Value { get; set; }
    public SortByEnum? SortBy { get; set; }
}