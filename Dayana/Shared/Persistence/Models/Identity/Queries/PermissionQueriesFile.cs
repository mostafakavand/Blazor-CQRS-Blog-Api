using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Infrastructure.Pagination;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Queries;
public record GetPermissionsByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPermissionsByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public DefaultPaginationFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}
