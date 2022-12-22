using Dayana.Server.Application.Specifications.Blog;
using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using Dayana.Shared.Persistence.Models.Blog.Queries;
using MediatR;

namespace Dayana.Server.Application.Handlers.Blog;

#region Post

public class CreatePostHandler : IRequestHandler<CreatePostCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePostHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.BlogPosts
            .ExistsAsync(new DuplicatePostSpecification(request.Title).ToExpression());

        if (isExist)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Post>.DuplicateError("Post name"));

        var entity = new Post()
        {
            PostTitle = request.Title,
            PostBody = request.TextContent,
            PostCategoryId = request.PostCategoryId,
            PostWriterId = request.RequestInfo.UserId,
            CreatedAt = DateTime.UtcNow,
            Subject = request.Subject,
            Summary = request.Summery,
            UpdatedAt = DateTime.UtcNow,
        };

        await _unitOfWork.BlogPosts.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}

public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePostHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.BlogPosts
            .ExistsAsync(new DuplicatePostSpecification(request.Title).ToExpression());

        if (isExist)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Post>.DuplicateError("Post name"));

        var entity = new Post()
        {
            Id= request.Id,
            PostTitle = request.Title,
            PostBody = request.TextContent,
            PostCategoryId = request.PostCategoryId,
            PostWriterId = request.RequestInfo.UserId,
            Subject = request.Subject,
            Summary = request.Summery,
            UpdatedAt = DateTime.UtcNow,
        };

        _unitOfWork.BlogPosts.Update(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}

public class DeletePostHandler : IRequestHandler<DeletePostCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePostHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.BlogPosts.GetPostByIdAsync(request.Id);        

        if(entity == null) 
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Post>.NotFoundError("id"));

        _unitOfWork.BlogPosts.Remove(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}

public class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPostByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.BlogPosts.GetPostByIdAsync(request.PostId);

        if (entity == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Post>.NotFoundError("id"));

        _unitOfWork.BlogPosts.Remove(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}
#endregion
