using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;

namespace Dayana.Shared.Persistence.Models.Blog.Filters;

public record PostCommentFilter : PaginationFilter
{
    public PostCommentFilter(int page, int pageSize) : base(page, pageSize)
    {

    }

    public string KeyWord { get; set; }

    public SortByEnum? SortBy { get; set; }
}

public record PostCategoryCommentFilter : PaginationFilter
{
    public PostCategoryCommentFilter(int page, int pageSize) : base(page, pageSize)
    {

    }

    public string KeyWord { get; set; }

    public SortByEnum? SortBy { get; set; }
}

public record PostCategoryIssueCommentFilter : PaginationFilter
{
    public PostCategoryIssueCommentFilter(int page, int pageSize) : base(page, pageSize)
    {

    }

    public string KeyWord { get; set; }

    public SortByEnum? SortBy { get; set; }
}

public record PostIssueCommentFilter : PaginationFilter
{
    public PostIssueCommentFilter(int page, int pageSize) : base(page, pageSize)
    {

    }

    public string KeyWord { get; set; }

    public SortByEnum? SortBy { get; set; }
}