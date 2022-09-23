using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Blog.Filters;

namespace Dayana.Server.Api.Models.Requests.Blog.PostCategoryRequests;

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