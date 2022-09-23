using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Blog.Filters;

public record PostIssueFilter : PaginationFilter
{
    public PostIssueFilter(int page, int pageSize) : base(page, pageSize) { }
}