using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Filters.Blog.PostFilters;

public class WeblogPostFilter : PaginationFilter
{
    public WeblogPostFilter(int page, int pageSize) : base(page, pageSize)
    {

    }

    public string KeyWord { get; set; }

    public WeblogPostSortBy? SortBy { get; set; }

}