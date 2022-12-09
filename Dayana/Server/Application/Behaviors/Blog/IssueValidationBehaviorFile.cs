using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using Dayana.Shared.Persistence.Models.Blog.Validators.CommandValidators;
using MediatR;

namespace Dayana.Server.Application.Behaviors.Blog;

#region Post Issue

public class CreatePostIssueValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<CreatePostIssueCommand, OperationResult>
{
    public async Task<OperationResult> Handle(CreatePostIssueCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new CreatePostIssueCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

public class UpdatePostIssueValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<UpdatePostIssueCommand, OperationResult>
{
    public async Task<OperationResult> Handle(UpdatePostIssueCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new UpdatePostIssueCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

public class DeletePostIssueValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<DeletePostIssueCommand, OperationResult>
{
    public async Task<OperationResult> Handle(DeletePostIssueCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new DeletePostIssueCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

#endregion

#region Post Category Issue

public class CreatePostCategoryIssueValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<CreatePostCategoryIssueCommand, OperationResult>
{
    public async Task<OperationResult> Handle(CreatePostCategoryIssueCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new CreatePostCategoryIssueCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

public class UpdatePostCategoryIssueValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<UpdatePostCategoryIssueCommand, OperationResult>
{
    public async Task<OperationResult> Handle(UpdatePostCategoryIssueCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new UpdatePostCategoryIssueCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

public class DeletePostCategoryIssueValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<DeletePostCategoryIssueCommand, OperationResult>
{
    public async Task<OperationResult> Handle(DeletePostCategoryIssueCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new DeletePostCategoryIssueCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

#endregion