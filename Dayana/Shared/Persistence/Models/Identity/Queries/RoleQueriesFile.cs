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


public class GetRoleByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetRoleByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int RoleId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}


public class GetRolesByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetRolesByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public RoleFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}
