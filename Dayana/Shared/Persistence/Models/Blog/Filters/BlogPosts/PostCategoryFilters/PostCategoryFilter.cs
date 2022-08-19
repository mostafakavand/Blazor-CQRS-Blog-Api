using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Blog.Filters.BlogPosts.PostCategoryFilters;

public class PostCategoryFilter : PaginationFilter
{
    public PostCategoryFilter(int page, int pageSize) : base(page, pageSize)
    {
    }
    public string KeyWord { get; set; }
    public PostCategorySortBy SortBy { get; set; }
}