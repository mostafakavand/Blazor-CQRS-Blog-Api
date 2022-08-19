using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Queries.Auth;

public class GetUserProfileQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetUserProfileQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public int UserId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}