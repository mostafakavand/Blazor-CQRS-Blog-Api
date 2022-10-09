using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Blog.Requests;

#region post

public record CreatePostIssueRequest
{
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }
}

public record GetPostIssueByFilterRequest : DefaultPaginationFilter
{
    protected GetPostIssueByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }
    public GetPostIssueByFilterRequest()
    {
    }
}

public record UpdatePostIssueRequest
{
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }
}

#endregion

#region post category

public record CreatePostCategoryIssueRequest
{
    public string CategoryTitle { get; set; }
    public string CategoryIcon { get; set; }
}
public record GetPostCategoryIssueByFilterRequst : DefaultPaginationFilter
{
    protected GetPostCategoryIssueByFilterRequst(int page, int pageSize) : base(page, pageSize)
    {
    }

    public GetPostCategoryIssueByFilterRequst()
    {
    }
}

public record UpdatPostCategoryeIssueRequest
{
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }
}

#endregion