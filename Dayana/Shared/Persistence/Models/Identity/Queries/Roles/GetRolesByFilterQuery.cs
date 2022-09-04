using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Identity.Filters;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Queries.Roles;

public class GetRolesByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetRolesByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public RoleFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}