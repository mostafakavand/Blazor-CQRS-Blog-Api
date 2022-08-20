using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using FluentValidation;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Commands.Users;

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


public class CreateUserPermissionCommandValidator : AbstractValidator<CreateUserPermissionCommand>
{
    public CreateUserPermissionCommandValidator()
    {

        RuleFor(x => x.PermissionId)
            .NotEmpty()
            .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);

        RuleFor(x => x.PermissionId)
            .GreaterThan(0)
            .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidUserIdValidationError);

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithState(_ => UserErrors.InvalidUserIdValidationError);

    }
}