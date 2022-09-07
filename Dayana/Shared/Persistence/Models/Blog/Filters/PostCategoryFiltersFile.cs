using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Blog.Filters.BlogPosts.PostCategoryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Filters;

public class PostCategoryFilter : PaginationFilter
{
    public PostCategoryFilter(int page, int pageSize) : base(page, pageSize)
    {
    }
    public string KeyWord { get; set; }
    public PostCategorySortBy SortBy { get; set; }
}


public enum PostCategorySortBy
{
    CreationDate = 12,
    CreationDateDescending = 13,
}