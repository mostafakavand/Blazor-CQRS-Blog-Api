using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using Dayana.Shared.Persistence.Models.Blog.Validators.CommandValidators;
using MediatR;

namespace Dayana.Server.Application.Behaviors.Blog;

#region Post

public class CreatePostValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<CreatePostCommand, OperationResult>
{
    public async Task<OperationResult> Handle(CreatePostCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new CreatePostCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

public class UpdatePostValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<UpdatePostCommand, OperationResult>
{
    public async Task<OperationResult> Handle(UpdatePostCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new UpdatePostCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

public class DeletePostValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<DeletePostCommand, OperationResult>
{
    public async Task<OperationResult> Handle(DeletePostCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new DeletePostCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

#endregion

#region Post Category

public class CreatePostCategoryValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<CreatePostCategoryCommand, OperationResult>
{
    public async Task<OperationResult> Handle(CreatePostCategoryCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new CreatePostCategoryCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

public class UpdatePostCategoryValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<UpdatePostCategoryCommand, OperationResult>
{
    public async Task<OperationResult> Handle(UpdatePostCategoryCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new UpdatePostCategoryCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

public class DeletePostCategoryValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<DeletePostCategoryCommand, OperationResult>
{
    public async Task<OperationResult> Handle(DeletePostCategoryCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new DeletePostCategoryCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

#endregion