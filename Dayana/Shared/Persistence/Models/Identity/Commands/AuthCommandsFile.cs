using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Identity.Commands;

public class LoginCommand : IRequestInfo, IRequest<OperationResult>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}