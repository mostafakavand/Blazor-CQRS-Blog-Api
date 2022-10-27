using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Blog.Requests;

#region post

public record CreatePostIssueRequest
{
    public string PostEid { get; set; }
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
    public string PostEid { get; set; }
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }
}

#endregion

#region post category

public record CreatePostCategoryIssueRequest
{
    public string PostCategoryEid { get; set; }
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }
}
public record GetPostCategoryIssueByFilterRequest : DefaultPaginationFilter
{
    protected GetPostCategoryIssueByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }

    public GetPostCategoryIssueByFilterRequest()
    {
    }
}

public record UpdatePostCategoryIssueRequest
{
    public string PostCategoryEid { get; set; }
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }
}

#endregion