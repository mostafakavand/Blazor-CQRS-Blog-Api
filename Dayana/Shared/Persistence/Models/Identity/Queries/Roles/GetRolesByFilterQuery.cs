using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;
using Dayana.Shared.Persistence.Models.Identity.Filters.Roles;

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