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

public class PostIssueCommentController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostIssueCommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(BlogRoutes.PostIssueComment + "add")]
    [CreatePostIssueCommentResultFilter]
    public async Task<IActionResult> AddPostIssueComment([FromBody] CreatePostIssueCommentRequest request)
    {
        var operation = await _mediator.Send(new CreatePostIssueCommentCommand(Request.GetRequestInfo())
        {
            CommentOwnerId = request.CommentOwnerEid.DecodeInt(),
            PostIssueId = request.CommentPostIssueEid.DecodeInt(),
            CommentText = request.CommentText,
            IsReply = request.IsReply,
            ReplyToCommentId = request.IsReply ? request.ReplyToCommentEid?.DecodeInt() : null,
        });

        return this.ReturnResponse(operation);
    }

    [HttpPut(BlogRoutes.PostIssueComment + "update/{wpiceid}")]
    [UpdatePostIssueCommentResultFilter]
    public async Task<IActionResult> UpdatePostIssueComment([FromRoute] string wpiceid, [FromBody] UpdatePostIssueCommentRequest request)
    {
        var operation = await _mediator.Send(new UpdatePostIssueCommentCommand(Request.GetRequestInfo())
        {
            Id = wpiceid.DecodeInt(),
            CommentOwnerId = request.CommentOwnerEid.DecodeInt(),
            PostIssueId = request.CommentPostIssueEid.DecodeInt(),
            CommentText = request.CommentText,
            IsReply = request.IsReply,
            ReplyToCommentId = request.IsReply ? request.ReplyToCommentEid?.DecodeInt() : null,
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(BlogRoutes.PostIssueComment + "get_by_id/{wpiceid}")]
    [GetPostIssueCommentByIdResultFilter]
    public async Task<IActionResult> GetWeblogPostIssueCommentById([FromRoute] string wpiceid)
    {
        var operation = await _mediator.Send(new GetPostIssueCommentByIdQuery(Request.GetRequestInfo())
        {
            PostIssueId = wpiceid.DecodeInt(),
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(BlogRoutes.PostIssueComment + "get_PostIssueComments_by_filter")]
    [GetPostIssueCommentByFilterResultFilter]
    public async Task<IActionResult> GetPostIssueCommentsByFilter([FromQuery] GetPostIssueCommentByFilterRequest request)
    {
        var operation = await _mediator.Send(new GetPostIssueCommentByFilterQuery(Request.GetRequestInfo())
        {
            Filter = new DefaultPaginationFilter(request.Page, request.PageSize)
            {
                keyword = request?.keyword ?? "",
                SortBy = request?.SortBy,
            },
        });

        return this.ReturnResponse(operation);
    }

    [HttpDelete(BlogRoutes.PostIssueComment + "{wpiceid}")]
    [DeletePostIssueCommentResultFilter]
    public async Task<IActionResult> DeletePostIssueComment([FromRoute] string wpiceid)
    {
        var operation = await _mediator.Send(new DeletePostIssueCommentCommand(Request.GetRequestInfo())
        {
            Id = wpiceid.DecodeInt(),
        });

        return this.ReturnResponse(operation);
    }
}