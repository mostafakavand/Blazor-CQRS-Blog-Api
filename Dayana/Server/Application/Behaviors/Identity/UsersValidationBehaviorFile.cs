using Dayana.Server.Application.Validators.Identity.Users;
using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using MediatR;

namespace Dayana.Server.Application.Behaviors.Identity;

#region user

public class CreateUserValidationBehavior<TRequest, TResponse> : IPipelineBehavior<CreateUserCommand, OperationResult>
{
    public async Task<OperationResult> Handle(CreateUserCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new CreateUserCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

public class DeleteUserValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<DeleteUserCommand, OperationResult>
{
    public async Task<OperationResult> Handle(DeleteUserCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new DeleteUserCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

public class UpdateUserValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<UpdateUserCommand, OperationResult>
{
    public async Task<OperationResult> Handle(UpdateUserCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new UpdateUserCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}
#endregion

#region user permission

public class CreateUserPermissionValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<CreateUserPermissionCommand, OperationResult>
{
    public async Task<OperationResult> Handle(CreateUserPermissionCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new CreateUserPermissionCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

public class DeleteUserPermissionValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<DeleteUserPermissionCommand, OperationResult>
{
    public async Task<OperationResult> Handle(DeleteUserPermissionCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new DeleteUserPermissionCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}
#endregion

#region user role

public class UpdateUserRolesValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<UpdateUserRolesCommand, OperationResult>
{
    public async Task<OperationResult> Handle(UpdateUserRolesCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new UpdateUserRolesCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

#endregion