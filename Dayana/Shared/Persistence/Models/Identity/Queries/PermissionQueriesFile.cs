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
public class GetPermissionsByFilterQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetPermissionsByFilterQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public PermissionFilter Filter { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}
