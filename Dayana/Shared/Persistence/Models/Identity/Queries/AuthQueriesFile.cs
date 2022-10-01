using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Queries;
public record GetUserProfileQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetUserProfileQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public int UserId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

public record RefreshTokenQuery : IRequestInfo, IRequest<OperationResult>
{
    public RequestInfo RequestInfo { get; private set; }
    public RefreshTokenQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public string RefreshToken { get; set; }
}