using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Queries.Roles;

public class GetRoleByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetRoleByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int RoleId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}