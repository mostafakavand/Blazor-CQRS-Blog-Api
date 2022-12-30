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

public class PostCommentController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostCommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(BlogRoutes.PostComment + "add")]
    [CreatePostCommentResultFilter]
    public async Task<IActionResult> AddPostComment([FromBody] CreatePostCommentRequest request)
    {
        var operation = await _mediator.Send(new CreatePostCommentCommand(Request.GetRequestInfo())
        {
            CommentOwnerId = request.CommentOwnerEid.DecodeInt(),
            PostId = request.CommentPostEid.DecodeInt(),
            CommentText = request.CommentText,
            IsReply = request.IsReply,
            ReplyToCommentId = request.IsReply ? request.ReplyToCommentEid?.DecodeInt() : null,
        });

        return this.ReturnResponse(operation);
    }

    [HttpPut(BlogRoutes.PostComment + "update/{wpceid}")]
    [UpdatePostCommentResultFilter]
    public async Task<IActionResult> UpdatePostComment([FromRoute] string wpceid, [FromBody] UpdatePostCommentRequest request)
    {
        var operation = await _mediator.Send(new UpdatePostCommentCommand(Request.GetRequestInfo())
        {
            Id = wpceid.DecodeInt(),
            CommentOwnerId = request.CommentOwnerEid.DecodeInt(),
            PostId = request.CommentPostEid.DecodeInt(),
            CommentText = request.CommentText,
            IsReply = request.IsReply,
            ReplyToCommentId = request.IsReply ? request.ReplyToCommentEid?.DecodeInt() : null,
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(BlogRoutes.PostComment + "get_by_id/{wpceid}")]
    [GetPostCommentByIdResultFilter]
    public async Task<IActionResult> GetWeblogPostCommentById([FromRoute] string wpceid)
    {
        var operation = await _mediator.Send(new GetPostCommentByIdQuery(Request.GetRequestInfo())
        {
            PostCommentId = wpceid.DecodeInt(),
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(BlogRoutes.PostComment + "get_PostComments_by_filter")]
    [GetPostCommentByFilterResultFilter]
    public async Task<IActionResult> GetPostCommentsByFilter([FromQuery] GetPostCommentByFilterRequest request)
    {
        var operation = await _mediator.Send(new GetPostCommentByFilterQuery(Request.GetRequestInfo())
        {
            Filter = new DefaultPaginationFilter(request.Page, request.PageSize)
            {
                keyword = request?.keyword ?? "",
                SortBy = request?.SortBy,
            },
        });

        return this.ReturnResponse(operation);
    }

    [HttpDelete(BlogRoutes.PostComment + "{wpceid}")]
    [DeletePostCommentResultFilter]
    public async Task<IActionResult> DeletePostComment([FromRoute] string wpceid)
    {
        var operation = await _mediator.Send(new DeletePostCommentCommand(Request.GetRequestInfo())
        {
            Id = wpceid.DecodeInt(),
        });

        return this.ReturnResponse(operation);
    }
}