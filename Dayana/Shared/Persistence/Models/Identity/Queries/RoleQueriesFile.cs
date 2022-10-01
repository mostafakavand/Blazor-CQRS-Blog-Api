using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Infrastructure.Pagination;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Queries;


public record GetRoleByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetRoleByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int RoleId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}


public record GetRolesByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetRolesByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public DefaultPaginationFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}
