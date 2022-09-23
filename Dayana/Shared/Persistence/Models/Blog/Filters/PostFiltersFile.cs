using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;

namespace Dayana.Shared.Persistence.Models.Blog.Filters;

public record PostFilter : PaginationFilter
{
    public PostFilter(int page, int pageSize) : base(page, pageSize)
    {

    }

    public string KeyWord { get; set; }

    public SortByEnum? SortBy { get; set; }
}

public record PostCategoryFilter : PaginationFilter
{
    public PostCategoryFilter(int page, int pageSize) : base(page, pageSize)
    {
    }
    public string KeyWord { get; set; }
    public SortByEnum SortBy { get; set; }
}