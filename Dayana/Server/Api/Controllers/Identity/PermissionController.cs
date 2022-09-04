using Dayana.Server.Api.ResultFilters.Identity.Permissions;
using Dayana.Server.Api.Routes;
using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Persistence.Models.Identity.Filters;
using Dayana.Shared.Persistence.Models.Identity.Queries.Permissions;
using Dayana.Shared.Persistence.Models.Identity.Requests.Permissions;
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

    [HttpGet(IdentityRoutes.Permissions)]
    [GetPermissionsResultFilter]
    public async Task<IActionResult> GetPermissionsByFilter([FromQuery] GetPermissionsByFilterRequest request)
    {
        var roleId = request.RoleEid?.DecodeInt();

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
