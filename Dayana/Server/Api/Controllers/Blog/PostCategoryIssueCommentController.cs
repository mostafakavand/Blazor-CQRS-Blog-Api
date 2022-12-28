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

public class PostCategoryIssueCommentController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostCategoryIssueCommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(BlogRoutes.PostCategoryIssueComment + "add")]
    [CreatePostCategoryIssueCommentResultFilter]
    public async Task<IActionResult> AddPostCategoryIssueComment([FromBody] CreatePostCategoryIssueCommentRequest request)
    {
        var operation = await _mediator.Send(new CreatePostCategoryIssueCommentCommand(Request.GetRequestInfo())
        {
            CommentOwnerId = request.CommentOwnerEid.DecodeInt(),
            PostCategoryIssueId = request.CommentPostCategoryIssueEid.DecodeInt(),
            CommentText = request.CommentText,
            IsReply = request.IsReply,
            ReplyToCommentId = request.IsReply ? request.ReplyToCommentEid?.DecodeInt() : null,
        });

        return this.ReturnResponse(operation);
    }

    [HttpPut(BlogRoutes.PostCategoryIssueComment + "update/{wpciceid}")]
    [UpdatePostCategoryIssueCommentResultFilter]
    public async Task<IActionResult> UpdatePostCategoryIssueComment([FromRoute] string wpiceid, [FromBody] UpdatePostCategoryIssueCommentRequest request)
    {
        var operation = await _mediator.Send(new UpdatePostCategoryIssueCommentCommand(Request.GetRequestInfo())
        {
            Id = wpiceid.DecodeInt(),
            CommentOwnerId = request.CommentOwnerEid.DecodeInt(),
            PostCategoryIssueId = request.CommentPostCategoryIssueEid.DecodeInt(),
            CommentText = request.CommentText,
            IsReply = request.IsReply,
            ReplyToCommentId = request.IsReply ? request.ReplyToCommentEid?.DecodeInt() : null,
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(BlogRoutes.PostCategoryIssueComment + "get_by_id/{wpciceid}")]
    [GetPostCategoryIssueCommentByIdResultFilter]
    public async Task<IActionResult> GetWeblogPostCategoryIssueCommentById([FromRoute] string wpciceid)
    {
        var operation = await _mediator.Send(new GetPostCategoryIssueCommentByIdQuery(Request.GetRequestInfo())
        {
            PostCategoryIssueId = wpciceid.DecodeInt(),
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(BlogRoutes.PostCategoryIssueComment + "get_PostCategoryIssueComments_by_filter")]
    [GetPostCategoryIssueCommentByFilterResultFilter]
    public async Task<IActionResult> GetPostCategoryIssueCommentsByFilter([FromQuery] GetPostCategoryIssueCommentByFilterRequest request)
    {
        var operation = await _mediator.Send(new GetPostCategoryIssueCommentByFilterQuery(Request.GetRequestInfo())
        {
            Filter = new DefaultPaginationFilter(request.Page, request.PageSize)
            {
                keyword = request?.keyword ?? "",
                SortBy = request?.SortBy,
            },
        });

        return this.ReturnResponse(operation);
    }

    [HttpDelete(BlogRoutes.PostCategoryIssueComment + "{wpciceid}")]
    [DeletePostCategoryIssueCommentResultFilter]
    public async Task<IActionResult> DeletePostCategoryIssueComment([FromRoute] string wpciceid)
    {
        var operation = await _mediator.Send(new DeletePostCategoryIssueCommentCommand(Request.GetRequestInfo())
        {
            Id = wpciceid.DecodeInt(),
        });

        return this.ReturnResponse(operation);
    }
}