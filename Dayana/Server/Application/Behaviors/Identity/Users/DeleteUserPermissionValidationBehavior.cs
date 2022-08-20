﻿using MediatR;

namespace Dayana.Server.Application.Behaviors.Identity.Users;

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