using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Infrastructure.Routes;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Dayana.Server.Api.Controllers.Identity;

[ApiController]
public class DevController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public DevController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet(IdentityRoutes.Dev + "hashid/encode/{id}")] // api/dev/hashid/encode/id
                                                         //[Authorize(Permission.DevelopmentAll)]
    public ActionResult GetEncodedId([FromRoute] int id)
    {
        return Ok(id.EncodeInt());
    }

    [HttpGet(IdentityRoutes.Dev + "hashid/decode/{eid}")] // api/dev/hashid/decode/eid
                                                          //[Authorize(Permission.DevelopmentAll)]
    public ActionResult GetDecodedEid([FromRoute] string eid)
    {
        return Ok(eid.DecodeInt());
    }
}
