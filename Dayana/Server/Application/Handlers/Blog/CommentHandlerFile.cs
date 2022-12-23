using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using MediatR;

namespace Dayana.Server.Application.Handlers.Blog;

#region PostComment

public class CreatePostCommentHandler : IRequestHandler<CreatePostCommentCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePostCommentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(CreatePostCommentCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.BlogPostComments
            .ExistsAsync(new DuplicatePostCommentSpecification(request.Title).ToExpression());

        if (isExist)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostComment>.DuplicateError("PostComment name"));
        }

        var entity = new PostComment()
        {
            PostCommentTitle = request.Title,
            PostCommentBody = request.TextContent,
            PostCommentCategoryId = request.PostCommentCategoryId,
            PostCommentWriterId = request.RequestInfo.UserId,
            CreatedAt = DateTime.UtcNow,
            Subject = request.Subject,
            Summary = request.Summery,
            UpdatedAt = DateTime.UtcNow,
            CreatorId = request.RequestInfo.UserId,
        };

        await _unitOfWork.BlogPostComments.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class UpdatePostCommentHandler : IRequestHandler<UpdatePostCommentCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePostCommentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(UpdatePostCommentCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.BlogPostComments
            .ExistsAsync(new DuplicatePostCommentSpecification(request.Title).ToExpression());

        if (isExist)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostComment>.DuplicateError("PostComment name"));
        }

        var entity = new PostComment()
        {
            Id = request.Id,
            PostCommentTitle = request.Title,
            PostCommentBody = request.TextContent,
            PostCommentCategoryId = request.PostCommentCategoryId,
            PostCommentWriterId = request.RequestInfo.UserId,
            Subject = request.Subject,
            Summary = request.Summery,
            UpdatedAt = DateTime.UtcNow,
            UpdaterId = request.RequestInfo.UserId,
        };

        _unitOfWork.BlogPostComments.Update(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class DeletePostCommentHandler : IRequestHandler<DeletePostCommentCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePostCommentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(DeletePostCommentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.BlogPostComments.GetPostCommentByIdAsync(request.Id);

        if (entity == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostComment>.NotFoundError("id"));
        }

        _unitOfWork.BlogPostComments.Remove(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class GetPostCommentByIdHandler : IRequestHandler<GetPostCommentByIdQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetPostCommentByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetPostCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.BlogPostComments.GetPostCommentByIdAsync(request.PostCommentId);
        if (entity == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostComment>.NotFoundError("id"));
        }

        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: _mapper.Map<PostCommentModel>(entity));
    }
}

public class GetPostCommentByFilterHandler : IRequestHandler<GetPostCommentByFilterQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPostCommentByFilterHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetPostCommentByFilterQuery request, CancellationToken cancellationToken)
    {
        var entityList = await _unitOfWork.BlogPostComments.GetPostCommentsByFilterAsync(filter: request.Filter);
        if (entityList == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostCommentCategory>.DuplicateError("e"));
        }

        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: _mapper.Map<List<PostCommentModel>>(entityList));
    }
}

#endregion
