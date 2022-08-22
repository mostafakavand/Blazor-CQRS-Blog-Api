using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dayana.Server.Api.Controllers.Identity;

[ApiController]
public class PermissionController : ControllerBase
{
    private readonly IMediator _mediator;

    public PermissionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Routes.Permissions)]
    [GetPermissionsResultFilter]
    public async Task<IActionResult> GetPermissionsByFilter([FromQuery] GetPermissionsByFilterRequest request)
    {
        var roleId = request.RoleEid?.Decode();

        var operation = await _mediator.Send(new GetPermissionsByFilterQuery(Request.GetRequestInfo())
        {
            Filter = new PermissionFilter(request.Page, request.PageSize)
            {
                RoleId = roleId,
                Value = request.Value,
                Name = request.Name,
                Title = request.Title
            },
        });

        return this.ReturnResponse(operation);
    }
}
