using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Identity.Filters.Users;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Queries.Users;

public class GetUsersByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetUsersByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public UserFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}