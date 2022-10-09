using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Models.Blog.Requests;


#region Post
public record CreatePostRequest
{
    public string Title { get; set; }
    public string Summery { get; set; }
    public string TextContent { get; set; }
}

public record GetPostByFilterRequest : DefaultPaginationFilter
{
    protected GetPostByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }
    public GetPostByFilterRequest()
    {
    }
}

public record UpdatePostRequest
{
    public string Title { get; set; }
    public string Summery { get; set; }
    public string TextContent { get; set; }
}
#endregion

#region Post Category
public record CreatePostCategoryRequest
{
    public string CategoryTitle { get; set; }
    public string CategoryIcon { get; set; }
}
public record GetPostCategoryByFilterRequst : DefaultPaginationFilter
{
    protected GetPostCategoryByFilterRequst(int page, int pageSize) : base(page, pageSize)
    {
    }

    public GetPostCategoryByFilterRequst()
    {
    }
}

public record UpdatePostCategoryRequest
{
    public string CategoryTitle { get; set; }
    public string CategoryIcon { get; set; }
}

#endregion