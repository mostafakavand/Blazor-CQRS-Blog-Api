using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Blog.Requests.PostRequests;

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