using Dayana.Shared.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Requests;

#region post

public record CreatePostCommentRequest
{
    public string CommentTitle { get; set; }
    public string CommentDescription { get; set; }
}

public record GetPostCommentByFilterRequest : DefaultPaginationFilter
{
    protected GetPostCommentByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }
    public GetPostCommentByFilterRequest()
    {
    }
    public string? keyword { get; set; }
}

public record UpdatePostCommentRequest
{
    public string CommentTitle { get; set; }
    public string CommentDescription { get; set; }
}

#endregion

#region post category

public record CreatePostCategoryCommentRequest
{
    public string CategoryTitle { get; set; }
    public string CategoryIcon { get; set; }
}
public record GetPostCategoryCommentByFilterRequst : DefaultPaginationFilter
{
    protected GetPostCategoryCommentByFilterRequst(int page, int pageSize) : base(page, pageSize)
    {
    }

    public GetPostCategoryCommentByFilterRequst()
    {
    }
    public string? keyword { get; set; }
}

public record UpdatPostCategoryeCommentRequest
{
    public string CommentTitle { get; set; }
    public string CommentDescription { get; set; }
}

#endregion