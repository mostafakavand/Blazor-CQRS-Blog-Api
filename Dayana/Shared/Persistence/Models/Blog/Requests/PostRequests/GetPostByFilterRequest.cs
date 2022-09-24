using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;

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