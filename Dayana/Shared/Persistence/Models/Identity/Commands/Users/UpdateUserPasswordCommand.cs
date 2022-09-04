using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Commands.Users;

public class UpdateUserPasswordCommand : IRequestInfo, IRequest<OperationResult>
{
    public UpdateUserPasswordCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int UserId { get; set; }
    public string NewPassword { get; set; }
    public string LastPassword { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}