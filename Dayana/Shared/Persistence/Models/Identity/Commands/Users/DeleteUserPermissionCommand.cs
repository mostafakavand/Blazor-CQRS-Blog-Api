using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Commands.Users;

public class DeleteUserPermissionCommand : IRequestInfo, IRequest<OperationResult>
{
    public DeleteUserPermissionCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int ClaimId { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}