using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Server.Api.Models.Requests.Blog.PostRequests;

public record GetPostByFilterRequest : DefaultPaginationFilter
{
    protected GetPostByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }

    public GetPostByFilterRequest()
    {
    }
}