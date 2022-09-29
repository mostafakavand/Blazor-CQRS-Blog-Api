using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Commands;

public record LoginCommand : IRequestInfo, IRequest<OperationResult>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}