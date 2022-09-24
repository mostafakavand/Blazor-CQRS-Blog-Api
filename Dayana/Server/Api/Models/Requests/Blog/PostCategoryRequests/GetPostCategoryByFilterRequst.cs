using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Server.Api.Models.Requests.Blog.PostCategoryRequests;

public record GetPostCategoryByFilterRequst : DefaultPaginationFilter
{
    protected GetPostCategoryByFilterRequst(int page, int pageSize) : base(page, pageSize)
    {
    }

    public GetPostCategoryByFilterRequst()
    {
    }
}