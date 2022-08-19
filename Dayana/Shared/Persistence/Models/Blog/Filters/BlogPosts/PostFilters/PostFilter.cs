using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Blog.Filters.BlogPosts.PostFilters;

public class PostFilter : PaginationFilter
{
    public PostFilter(int page, int pageSize) : base(page, pageSize)
    {

    }

    public string KeyWord { get; set; }

    public PostSortBy? SortBy { get; set; }

}