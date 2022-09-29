using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Commands;

public record CreateRoleCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreateRoleCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public string Title { get; set; }
    public IList<int> PermissionIds { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}


public record DeleteRoleCommand : IRequestInfo, IRequest<OperationResult>
{
    public DeleteRoleCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public int RoleId { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}

public record UpdateRoleCommand : IRequestInfo, IRequest<OperationResult>
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