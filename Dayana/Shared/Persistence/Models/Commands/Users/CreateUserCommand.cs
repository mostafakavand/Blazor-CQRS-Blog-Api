using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Commands.Users;

public class CreateUserCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreateUserCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public string Username { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserState State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}