using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Queries.Users;

public class GetUserByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetUserByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public GetUserByIdQuery()
    {
    }

    public int UserId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}