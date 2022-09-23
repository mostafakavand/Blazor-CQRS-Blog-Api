using Dayana.Shared.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Filters;

public record PostIssueFilter: PaginationFilter
{
	public PostIssueFilter(int page, int pageSize): base(page, pageSize) {}

    public string KeyWord { get; set; }

    public PostCommentSortBy? SortBy { get; set; }
}