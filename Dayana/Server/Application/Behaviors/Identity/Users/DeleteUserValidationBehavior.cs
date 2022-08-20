﻿using MediatR;

namespace Dayana.Server.Application.Behaviors.Identity.Users;

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