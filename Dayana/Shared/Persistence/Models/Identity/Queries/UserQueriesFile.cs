using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Queries;


public record GetUserByIdQuery : IRequestInfo, IRequest<OperationResult>
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


public record GetUsersByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetUsersByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public CustomaizedPaginationFilterTwo<List<UserState>?, UserSortBy?> Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}