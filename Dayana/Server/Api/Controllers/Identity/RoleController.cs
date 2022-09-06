using Dayana.Server.Api.ResultFilters.Identity.Roles;
using Dayana.Server.Api.Routes;
using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using Dayana.Shared.Persistence.Models.Identity.Filters;
using Dayana.Shared.Persistence.Models.Identity.Queries;
using Dayana.Shared.Persistence.Models.Identity.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dayana.Server.Api.Controllers.Identity;

[ApiController]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(IdentityRoutes.Roles)]
    [CreateRoleResultFilter]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
    {
        var permissionIds = request.PermissionEids.Select(x => x.DecodeInt()).ToList();

        Shared.Infrastructure.Operations.OperationResult operation = await _mediator.Send(new CreateRoleCommand(Request.GetRequestInfo())
        {
            Title = request.Title,
            PermissionIds = permissionIds
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(IdentityRoutes.Roles)]
    [GetRolesByFilterResultFilter]
    public async Task<IActionResult> GetRolesByFilter([FromQuery] GetRolesByFilterRequest request)
    {
        var permissionIds = request.PermissionEids != null && request.PermissionEids.Any() ? request.PermissionEids.Select(x => x.DecodeInt()).ToArray() : null;

        var operation = await _mediator.Send(new GetRolesByFilterQuery(Request.GetRequestInfo())
        {
            Filter = new RoleFilter(request.Page, request.PageSize)
            {
                PermissionIds = permissionIds ?? Array.Empty<int>(),
                SortBy = request.SortBy,
                Title = request.Title ?? "undefind-role"
            },
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(IdentityRoutes.Roles + "{reid}")]
    [GetRoleByIdResultFilter]
    public async Task<IActionResult> GetRoleById([FromRoute] string reid)
    {
        var roleId = reid.DecodeInt();

        var operation = await _mediator.Send(new GetRoleByIdQuery(Request.GetRequestInfo())
        {
            RoleId = roleId
        });

        return this.ReturnResponse(operation);
    }


    [HttpDelete(IdentityRoutes.Roles + "{reid}")]
    [DeleteRoleResultFilter]
    public async Task<IActionResult> DeleteRole([FromRoute] string reid)
    {
        var roleId = reid.DecodeInt();

        var operation = await _mediator.Send(new DeleteRoleCommand(Request.GetRequestInfo())
        {
            RoleId = roleId
        });

        return this.ReturnResponse(operation);
    }

    [HttpPut(IdentityRoutes.Roles + "{reid}")]
    [UpdateRoleResultFilter]
    public async Task<IActionResult> UpdateRole([FromRoute] string reid, [FromBody] UpdateRoleRequest request)
    {
        var roleId = reid.DecodeInt();
        var permissionIds = request.PermissionEids?.Select(x => x.DecodeInt()).ToList();

        var operation = await _mediator.Send(new UpdateRoleCommand(Request.GetRequestInfo())
        {
            RoleId = roleId,
            Title = request.Title,
            PermissionIds = permissionIds
            ?? new List<int> { }
        });

        return this.ReturnResponse(operation);
    }
}