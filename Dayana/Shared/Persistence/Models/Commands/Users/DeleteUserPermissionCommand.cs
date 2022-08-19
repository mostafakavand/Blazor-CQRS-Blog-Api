using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Commands.Users;

public class DeleteUserPermissionCommand : IRequestInfo, IRequest<OperationResult>
{
    public DeleteUserPermissionCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int ClaimId { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}