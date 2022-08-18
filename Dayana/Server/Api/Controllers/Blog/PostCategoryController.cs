using Dayana.Server.Api.ResultFilters.Weblog.WeblogPostCategoryResults;
using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Persistence.Models.Commands.Blog.PostCategoryCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dayana.Server.Api.Controllers.Weblog;

public class PostCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Routes.WeblogPostCategory + "AddPostCategory")]
    [CreateWeblogPostCategoryResultFilter]
    public async Task<IActionResult> AddWeblogPostCategory([FromBody] CreatePostCategoryRequest request)
    {
        var operation = await _mediator.Send(new CreatePostCategoryCommand(Request.GetRequestInfo())
        {
            CategoryTitle = request.CategoryTitle,
            CategoryIcon = request.CategoryIcon
        });

        return this.ReturnResponse(operation);
    }

    [HttpPut(Routes.WeblogPostCategory + "update/{wpceid}")]
    [UpdateWeblogPostCategoryResultFilter]
    public async Task<IActionResult> UpdateWeblogPostCategory([FromRoute] string wpceid, [FromBody] UpdatePostCategoryRequest request)
    {
        var Id = wpceid.DecodeInt();

        var operation = await _mediator.Send(new UpdateWeblogPostCategoryCommand(Request.GetRequestInfo())
        {
            Id = Id,
            CategoryTitle = request.CategoryTitle,
            CategoryIcon = request.CategoryIcon
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(Routes.WeblogPostCategory + "get_by_id/{wpceid}")]
    [GetWeblogPostCategoryByIdResultFilter]
    public async Task<IActionResult> GetWeblogPostCategoryById([FromRoute] string wpceid)
    {
        var Id = wpceid.DecodeInt();

        var operation = await _mediator.Send(new GetWeblogPostCategoryByIdQuery(Request.GetRequestInfo())
        {
            Id = Id,
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(Routes.WeblogPostCategory + "get_weblogpostCategories_by_filter")]
    [GetWeblogPostCategoryByFilterResultFilter]
    public async Task<IActionResult> GetWeblogPostCategoriesByFilter([FromQuery] GetWeblogPostCategoryByFilterRequst request)
    {
        var operation = await _mediator.Send(new GetWeblogPostCategoryByFilterQuery(Request.GetRequestInfo())
        {
            Filter = new WeblogPostCategoryFilter(request.Page, request.PageSize)
            {
                KeyWord = request?.Keyword ?? "",
                SortBy = request.SortBy,
            },
        });

        return this.ReturnResponse(operation);
    }

    [HttpDelete(Routes.WeblogPostCategory + "{wpceid}")]
    [DeleteWeblogPostCategoryResultFilter]
    public async Task<IActionResult> DeleteWeblogPostCategory([FromRoute] string wpceid)
    {
        var Id = wpceid.DecodeInt();

        var operation = await _mediator.Send(new DeleteWeblogPostCategoryCommand(Request.GetRequestInfo())
        {
            Id = Id,
        });

        return this.ReturnResponse(operation);
    }
}