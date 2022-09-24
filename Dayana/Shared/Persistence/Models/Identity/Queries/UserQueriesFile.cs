using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Queries;


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


public class GetUsersByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetUsersByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public CustomaizedPaginationFilter<List<UserState>?,UserSortBy?,string,string> Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}