using Dayana.Server.Api.ResultFilters.Identity;
using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Routes;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using Dayana.Shared.Persistence.Models.Identity.Queries;
using Dayana.Shared.Persistence.Models.Identity.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dayana.Server.Api.Controllers.Identity;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region User

    [HttpPost(IdentityRoutes.Users)]
    [CreateUserResultFilter]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var operation = await _mediator.Send(new CreateUserCommand(Request.GetRequestInfo())
        {
            Username = request.Username,
            Email = request.Email,
            Password = request.Password,
            Mobile = request.Mobile,
            State = UserState.Suspended
        });

        return this.ReturnResponse(operation);
    }

    [HttpPut(IdentityRoutes.Users + "{ueid}")]
    [UpdateUserResultFilter]
    public async Task<IActionResult> UpdateUser([FromRoute] string ueid, [FromBody] UpdateUserRequest request)
    {
        var userId = ueid.DecodeInt();

        var operation = await _mediator.Send(new UpdateUserCommand(Request.GetRequestInfo())
        {
            UserId = userId,
            Username = request.Username,
            Email = request.Email,
            Password = request.Password,
            Mobile = request.Mobile,
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(IdentityRoutes.Users + "{ueid}")]
    [GetUserByIdResultFilter]
    public async Task<IActionResult> GetUserById([FromRoute] string ueid)
    {
        var userId = ueid.DecodeInt();

        var operation = await _mediator.Send(new GetUserByIdQuery(Request.GetRequestInfo())
        {
            UserId = userId
        });

        return this.ReturnResponse(operation);
    }


    // Patch Password
    [HttpPatch(IdentityRoutes.Users + "{ueid}/password")]
    [UpdateUserResultFilter]
    public async Task<IActionResult> UpdateUserPassword([FromRoute] string ueid, [FromBody] UpdateUserPasswordRequest request)
    {
        var userId = ueid.DecodeInt();

        var operation = await _mediator.Send(new UpdateUserPasswordCommand(Request.GetRequestInfo())
        {
            UserId = userId,
            NewPassword = request.NewPassword
        });

        return this.ReturnResponse(operation);
    }

    #endregion

    #region Role

    [HttpPatch(IdentityRoutes.Users + "{ueid}/roles")]
    [UpdateUserRolesResultFilter]
    public async Task<IActionResult> UpdateUserRoles([FromRoute] string ueid, [FromBody] UpdateUserRolesRequest request)
    {
        var userId = ueid.DecodeInt();
        var roleIds = request.RoleEids?.Select(x => x.DecodeInt());

        var operation = await _mediator.Send(new UpdateUserRolesCommand(Request.GetRequestInfo())
        {
            UserId = userId,
            RoleIds = roleIds ?? Array.Empty<int>()
        });

        return this.ReturnResponse(operation);
    }

    #endregion

    #region Permission

    [HttpPost(IdentityRoutes.Users + "{ueid}/permissions/{peid}")]
    [CreateUserPermissionResultFilter]
    public async Task<IActionResult> CreateUserPermission([FromRoute] string ueid, [FromRoute] string peid)
    {
        var userId = ueid.DecodeInt();
        var permissionId = peid.DecodeInt();

        var operation = await _mediator.Send(new CreateUserPermissionCommand(Request.GetRequestInfo())
        {
            UserId = userId,
            PermissionId = permissionId
        });

        return this.ReturnResponse(operation);
    }

    [HttpDelete(IdentityRoutes.Users + "permission/{ceid}")]
    [DeleteUserPermissionResultFilter]
    public async Task<IActionResult> DeleteUserPermission([FromRoute] string ceid)
    {
        var claimId = ceid.DecodeInt();

        var operation = await _mediator.Send(new DeleteUserPermissionCommand(Request.GetRequestInfo())
        {
            ClaimId = claimId
        });

        return this.ReturnResponse(operation);
    }

    #endregion
}
