using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using Dayana.Shared.Persistence.Models.Blog.Validators.CommandValidators;
using MediatR;

namespace Dayana.Server.Application.Behaviors.Blog;

#region Post Comment

public class CreatePostCommentValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<CreatePostCommentCommand, OperationResult>
{
    public async Task<OperationResult> Handle(CreatePostCommentCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new CreatePostCommentCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

public class UpdatePostCommentValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<UpdatePostCommentCommand, OperationResult>
{
    public async Task<OperationResult> Handle(UpdatePostCommentCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new UpdatePostCommentCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

public class DeletePostCommentValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<DeletePostCommentCommand, OperationResult>
{
    public async Task<OperationResult> Handle(DeletePostCommentCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new DeletePostCommentCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

#endregion

#region Post And PostCategory Issue Comment

public class CreatePostIssueCommentValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<CreatePostIssueCommentCommand, OperationResult>
{
    public async Task<OperationResult> Handle(CreatePostIssueCommentCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new CreatePostIssueCommentCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

public class CreatePostCategoryIssueCommentValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<CreatePostCategoryIssueCommentCommand, OperationResult>
{
    public async Task<OperationResult> Handle(CreatePostCategoryIssueCommentCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new CreatePostCategoryIssueCommentCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}

#endregion
