using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Blog.Requests.PostRequests;

public record GetPostByFilterRequest : DefaultPaginationFilter
{
    protected GetPostByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }

    public GetPostByFilterRequest()
    {
    }
}