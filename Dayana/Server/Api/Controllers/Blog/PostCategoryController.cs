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

public class PostCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route(BlogRoutes.PostCategory + "add")]
    //[CreatePostCategoryResultFilter]
    public async Task<IActionResult> AddPostCategory([FromBody] CreatePostCategoryRequest request)
    {
        var operation = await _mediator.Send(new CreatePostCategoryCommand()
        {
            CategoryTitle = request.CategoryTitle,
            CategoryIcon = request.CategoryIcon
        });

        return this.ReturnResponse(operation);
    }

    [HttpPut(BlogRoutes.PostCategory + "update/{wpceid}")]
    [UpdatePostCategoryResultFilter]
    public async Task<IActionResult> UpdatePostCategory([FromRoute] string wpceid, [FromBody] UpdatePostCategoryRequest request)
    {
        var operation = await _mediator.Send(new UpdatePostCategoryCommand(Request.GetRequestInfo())
        {
            Id = wpceid.DecodeInt(),
            CategoryTitle = request.CategoryTitle,
            CategoryIcon = request.CategoryIcon
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(BlogRoutes.PostCategory + "get_by_id/{wpceid}")]
    [GetPostCategoryByIdResultFilter]
    public async Task<IActionResult> GetPostCategoryById([FromRoute] string wpceid)
    {
        var operation = await _mediator.Send(new GetPostCategoryByIdQuery(Request.GetRequestInfo())
        {
            Id = wpceid.DecodeInt(),
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(BlogRoutes.PostCategory + "get_postCategories_by_filter")]
    [GetPostCategoryByFilterResultFilter]
    public async Task<IActionResult> GetPostCategoriesByFilter([FromQuery] GetPostCategoryByFilterRequst request)
    {
        var operation = await _mediator.Send(new GetPostCategoryByFilterQuery(Request.GetRequestInfo())
        {
            Filter = new DefaultPaginationFilter(request.Page, request.PageSize)
            {
                keyword = request?.keyword ?? "",
                SortBy = request.SortBy,
            },
        });

        return this.ReturnResponse(operation);
    }

    [HttpDelete(BlogRoutes.PostCategory + "{wpceid}")]
    [DeletePostCategoryResultFilter]
    public async Task<IActionResult> DeletePostCategory([FromRoute] string wpceid)
    {
        var operation = await _mediator.Send(new DeletePostCategoryCommand(Request.GetRequestInfo())
        {
            Id = wpceid.DecodeInt(),
        });

        return this.ReturnResponse(operation);
    }
}