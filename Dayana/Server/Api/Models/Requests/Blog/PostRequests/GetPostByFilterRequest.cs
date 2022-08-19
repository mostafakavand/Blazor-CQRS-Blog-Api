using Illegible_Cms_V2.Server.Application.Models.Filters.Weblog.WeblogPostFilters;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;

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
    public WeblogPostSortBy SortBy { get; set; }
}