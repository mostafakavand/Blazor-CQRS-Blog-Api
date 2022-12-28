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

public class PostIssueController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostIssueController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(BlogRoutes.PostIssue + "add")]
    [CreatePostIssueResultFilter]
    public async Task<IActionResult> AddPostIssue([FromBody] CreatePostIssueRequest request)
    {
        var operation = await _mediator.Send(new CreatePostIssueCommand(Request.GetRequestInfo())
        {
            IssueDescription = request.IssueDescription,
            IssueTitle = request.IssueTitle,
            PostId = request.PostEid.DecodeInt()
        });

        return this.ReturnResponse(operation);
    }

    [HttpPut(BlogRoutes.PostIssue + "update/{wpieid}")]
    [UpdatePostIssueResultFilter]
    public async Task<IActionResult> UpdatePostIssue([FromRoute] string wpieid, [FromBody] UpdatePostIssueRequest request)
    {
        var operation = await _mediator.Send(new UpdatePostIssueCommand(Request.GetRequestInfo())
        {
            PosIssueId = wpieid.DecodeInt(),
            PostId = request.PostEid.DecodeInt(),
            IssueDescription = request.IssueDescription,
            IssueTitle = request.IssueTitle
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(BlogRoutes.PostIssue + "get_by_id/{wpieid}")]
    [GetPostIssueByIdResultFilter]
    public async Task<IActionResult> GetWeblogPostIssueById([FromRoute] string wpieid)
    {
        var operation = await _mediator.Send(new GetPostIssueByIdQuery(Request.GetRequestInfo())
        {
            PostIssueId = wpieid.DecodeInt(),
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(BlogRoutes.PostIssue + "get_PostIssues_by_filter")]
    [GetPostIssueByFilterResultFilter]
    public async Task<IActionResult> GetPostIssuesByFilter([FromQuery] GetPostIssueByFilterRequest request)
    {
        var operation = await _mediator.Send(new GetPostIssueByFilterQuery(Request.GetRequestInfo())
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

    [HttpDelete(BlogRoutes.PostIssue + "{wpieid}")]
    [DeletePostIssueResultFilter]
    public async Task<IActionResult> DeletePostIssue([FromRoute] string wpieid)
    {
        var operation = await _mediator.Send(new DeletePostIssueCommand(Request.GetRequestInfo())
        {
            Id = wpieid.DecodeInt(),
        });

        return this.ReturnResponse(operation);
    }
}