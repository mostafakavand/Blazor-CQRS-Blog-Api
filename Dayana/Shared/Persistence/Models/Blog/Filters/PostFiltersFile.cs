using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Blog.Filters.BlogPosts.PostFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Filters;

public class PostFilter : PaginationFilter
{
    public PostFilter(int page, int pageSize) : base(page, pageSize)
    {

    }

    public string KeyWord { get; set; }

    public PostSortBy? SortBy { get; set; }
}

public enum PostSortBy
{
    CreationDate = 12,
    CreationDateDescending = 13,
}