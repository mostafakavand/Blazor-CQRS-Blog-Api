using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Filters.Blog.PostFilters;

namespace Dayana.Server.Api.Models.Requests.Blog.PostRequests;

public class GetPostByFilterRequest : PaginationFilter
{
    protected GetPostByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }

    public GetPostByFilterRequest()
    {
    }

    public string? Keyword { get; set; }
    public PostSortBy SortBy { get; set; }
}