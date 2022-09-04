using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Commands.Roles;

public class UpdateRoleCommand : IRequestInfo, IRequest<OperationResult>
{
    public UpdateRoleCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int RoleId { get; set; }
    public string Title { get; set; }
    public IList<int> PermissionIds { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}