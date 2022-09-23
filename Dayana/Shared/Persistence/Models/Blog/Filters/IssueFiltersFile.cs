using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;
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

    public SortByEnum? SortBy { get; set; }
}