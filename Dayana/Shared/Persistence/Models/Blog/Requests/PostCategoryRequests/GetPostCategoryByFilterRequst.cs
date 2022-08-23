using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Blog.Filters.BlogPosts.PostCategoryFilters;

namespace Dayana.Shared.Persistence.Models.Blog.Requests.PostCategoryRequests;

public class GetPostCategoryByFilterRequst : PaginationFilter
{
    protected GetPostCategoryByFilterRequst(int page, int pageSize) : base(page, pageSize)
    {
    }

    public GetPostCategoryByFilterRequst()
    {
    }

    public string? Keyword { get; set; }
    public PostCategorySortBy SortBy { get; set; }
}