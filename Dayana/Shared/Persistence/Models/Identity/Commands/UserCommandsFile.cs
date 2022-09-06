using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Operations;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Commands;

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


public class CreateUserPermissionCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreateUserPermissionCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int UserId { get; set; }
    public int PermissionId { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}


public class DeleteUserCommand : IRequestInfo, IRequest<OperationResult>
{
    public DeleteUserCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int UserId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

public class DeleteUserPermissionCommand : IRequestInfo, IRequest<OperationResult>
{
    public DeleteUserPermissionCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int ClaimId { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}


public class UpdateUserCommand : IRequestInfo, IRequest<OperationResult>
{
    public UpdateUserCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int UserId { get; set; }
    public string Username { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserState State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}


public class UpdateUserPasswordCommand : IRequestInfo, IRequest<OperationResult>
{
    public UpdateUserPasswordCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int UserId { get; set; }
    public string NewPassword { get; set; }
    public string LastPassword { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}


public class UpdateUserRolesCommand : IRequestInfo, IRequest<OperationResult>
{
    public UpdateUserRolesCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int UserId { get; set; }
    public IEnumerable<int> RoleIds { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}