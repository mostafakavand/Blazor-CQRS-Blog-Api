using Dayana.Server.Api.ResultFilters.Identity;
using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Infrastructure.Routes;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using Dayana.Shared.Persistence.Models.Identity.Queries;
using Dayana.Shared.Persistence.Models.Identity.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dayana.Server.Api.Controllers.Identity;

public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(IdentityRoutes.Auth + "login")]
    [LoginResultFilter]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var operation = await _mediator.Send(new LoginCommand
        {
            UserName = request.Username,
            Password = request.Password,
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(IdentityRoutes.Auth + "token")]
    [TokenResultFilter]
    public async Task<IActionResult> GetAccessToken([FromHeader] string refresh)
    {
        var operation = await _mediator.Send(new RefreshTokenQuery(Request.GetRequestInfo())
        {
            RefreshToken = refresh
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(IdentityRoutes.Auth + "profile/{ueid}")]
    [GetProfileResultFilter]
    public async Task<IActionResult> Profile([FromRoute] string ueid)
    {
        var id = ueid.DecodeInt();

        var operation = await _mediator.Send(new GetUserProfileQuery(Request.GetRequestInfo())
        {
            UserId = id
        });

        return this.ReturnResponse(operation);
    }
}
