using Dayana.Server.Api.ResultFilters.Blog;
using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Infrastructure.Routes;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using Dayana.Shared.Persistence.Models.Blog.Queries;
using Dayana.Shared.Persistence.Models.Blog.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dayana.Server.Api.Controllers.Blog;

public class PostController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(BlogRoutes.Post + "add")]
    [CreatePostResultFilter]
    public async Task<IActionResult> AddPost([FromBody] CreatePostRequest request)
    {
        var operation = await _mediator.Send(new CreatePostCommand(Request.GetRequestInfo())
        {
            Title = request.Title,
            TextContent = request.TextContent,
            Summery = request.Summery,
        });

        return this.ReturnResponse(operation);
    }

    [HttpPut(BlogRoutes.Post + "update/{wpeid}")]
    [UpdatePostResultFilter]
    public async Task<IActionResult> UpdatePost([FromRoute] string wpeid, [FromBody] UpdatePostRequest request)
    {
        int Id = wpeid.DecodeInt();

        var operation = await _mediator.Send(new UpdatePostCommand(Request.GetRequestInfo())
        {
            Id = Id,
            Summery = request.Summery,
            Title = request.Title,
            TextContent = request.TextContent,
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(BlogRoutes.Post + "get_by_id/{wpeid}")]
    [GetPostByIdResultFilter]
    public async Task<IActionResult> GetWeblogPostById([FromRoute] string wpeid)
    {
        int Id = wpeid.DecodeInt();

        var operation = await _mediator.Send(new GetPostByIdQuery(Request.GetRequestInfo())
        {
            PostId = Id,
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(BlogRoutes.Post + "get_posts_by_filter")]
    [GetPostByFilterResultFilter]
    public async Task<IActionResult> GetPostsByFilter([FromQuery] GetPostByFilterRequest request)
    {
        var operation = await _mediator.Send(new GetPostByFilterQuery(Request.GetRequestInfo())
        {
            Filter = new DefaultPaginationFilter(request.Page, request.PageSize)
            {
                keyword = request?.keyword ?? "",
                SortBy = request?.SortBy,
            },
        });

        return this.ReturnResponse(operation);
    }

    [HttpDelete(BlogRoutes.Post + "{wpeid}")]
    [DeletePostResultFilter]
    public async Task<IActionResult> DeletePost([FromRoute] string wpeid)
    {
        int Id = wpeid.DecodeInt();

        var operation = await _mediator.Send(new DeletePostCommand(Request.GetRequestInfo())
        {
            Id = Id,
        });

        return this.ReturnResponse(operation);
    }
}