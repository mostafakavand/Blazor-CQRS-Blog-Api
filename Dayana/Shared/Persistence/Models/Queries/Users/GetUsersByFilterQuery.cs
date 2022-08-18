using Dayana.Shared.Persistence.Models.Filters.Users;
using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Queries.Users;

public class GetUsersByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetUsersByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public UserFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}