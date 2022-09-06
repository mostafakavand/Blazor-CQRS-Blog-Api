using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Identity.Filters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public UserFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}