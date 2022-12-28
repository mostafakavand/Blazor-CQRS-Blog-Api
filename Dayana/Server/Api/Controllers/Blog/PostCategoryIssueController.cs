

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

public class PostCategoryIssueController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostCategoryIssueController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(BlogRoutes.PostCategoryIssue + "add")]
    [CreatePostCategoryIssueResultFilter]
    public async Task<IActionResult> AddPostCategoryIssue([FromBody] CreatePostCategoryIssueRequest request)
    {
        var operation = await _mediator.Send(new CreatePostCategoryIssueCommand(Request.GetRequestInfo())
        {
            IssueDescription = request.IssueDescription,
            IssueTitle = request.IssueTitle,
            PostCategoryId = request.PostCategoryEid.DecodeInt()
        });

        return this.ReturnResponse(operation);
    }

    [HttpPut(BlogRoutes.PostCategoryIssue + "update/{wpcieid}")]
    [UpdatePostCategoryIssueResultFilter]
    public async Task<IActionResult> UpdatePostCategoryIssue([FromRoute] string wpcieid, [FromBody] UpdatePostCategoryIssueRequest request)
    {
        var operation = await _mediator.Send(new UpdatePostCategoryIssueCommand(Request.GetRequestInfo())
        {
            Id = wpcieid.DecodeInt(),
            PostCategoryId = request.PostCategoryEid.DecodeInt(),
            IssueDescription = request.IssueDescription,
            IssueTitle = request.IssueTitle
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(BlogRoutes.PostCategoryIssue + "get_by_id/{wpieid}")]
    [GetPostCategoryIssueByIdResultFilter]
    public async Task<IActionResult> GetWeblogPostCategoryIssueById([FromRoute] string wpieid)
    {
        var operation = await _mediator.Send(new GetPostCategoryIssueByIdQuery(Request.GetRequestInfo())
        {
            Id = wpieid.DecodeInt(),
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(BlogRoutes.PostCategoryIssue + "get_PostCategoryIssues_by_filter")]
    [GetPostCategoryIssueByFilterResultFilter]
    public async Task<IActionResult> GetPostCategoryIssuesByFilter([FromQuery] GetPostCategoryIssueByFilterRequest request)
    {
        var operation = await _mediator.Send(new GetPostCategoryIssueByFilterQuery(Request.GetRequestInfo())
        {
            Filter = new DefaultPaginationFilter(request.Page, request.PageSize)
            {
                keyword = request?.keyword ?? "",
                SortBy = request?.SortBy,
                CategoryId = request?.CategoryId,
                Id = request?.Id,
                Name = request?.Name,
                Title = request?.Title,
            },
        });

        return this.ReturnResponse(operation);
    }

    [HttpDelete(BlogRoutes.PostCategoryIssue + "{wpieid}")]
    [DeletePostCategoryIssueResultFilter]
    public async Task<IActionResult> DeletePostCategoryIssue([FromRoute] string wpieid)
    {
        var operation = await _mediator.Send(new DeletePostCategoryIssueCommand(Request.GetRequestInfo())
        {
            Id = wpieid.DecodeInt(),
        });

        return this.ReturnResponse(operation);
    }
}
