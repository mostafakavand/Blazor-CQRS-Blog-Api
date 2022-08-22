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

    [HttpPost(Routes.Auth + "login")]
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

    [HttpGet(Routes.Auth + "token")]
    [TokenResultFilter]
    public async Task<IActionResult> GetAccessToken([FromHeader] string refresh)
    {
        var operation = await _mediator.Send(new RefreshTokenQuery(Request.GetRequestInfo())
        {
            RefreshToken = refresh
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(Routes.Auth + "profile/{ueid}")]
    [GetProfileResultFilter]
    public async Task<IActionResult> Profile([FromRoute] string ueid)
    {
        var id = ueid.Decode();

        var operation = await _mediator.Send(new GetUserProfileQuery(Request.GetRequestInfo())
        {
            UserId = id
        });

        return this.ReturnResponse(operation);
    }
}
