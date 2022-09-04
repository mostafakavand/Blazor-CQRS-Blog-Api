using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Commands.Roles;

public class DeleteRoleCommand : IRequestInfo, IRequest<OperationResult>
{
    public DeleteRoleCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public int RoleId { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}