using Dayana.Shared.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Requests;


public class CreatePostRequest
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
    public string? keyword { get; set; }
}

public class UpdatePostRequest
{
    public string Title { get; set; }
    public string Summery { get; set; }
    public string TextContent { get; set; }
}
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
    public string? keyword { get; set; }
}

public class UpdatePostCategoryRequest
{
    public string CategoryTitle { get; set; }
    public string CategoryIcon { get; set; }
}
