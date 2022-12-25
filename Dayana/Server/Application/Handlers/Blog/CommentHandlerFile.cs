using AutoMapper;
using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Blog.Base;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using Dayana.Shared.Persistence.Models.Blog.Queries;
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


        var entity = new PostComment()
        {
            ReplyToCommentId = request.ReplyToCommentId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            CreatorId = request.RequestInfo.UserId,
            CommentText = request.CommentText,
            PostId = request.PostId,
            IsReply = request.IsReply,
            CommentOwnerId = request.CommentOwnerId,
        };

        await _unitOfWork.PostComments.AddAsync(entity);
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

        var entity = new PostComment()
        {
            Id = request.Id,
            ReplyToCommentId = request.ReplyToCommentId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            UpdaterId = request.RequestInfo.UserId,
            CommentText = request.CommentText,
            PostId = request.PostId,
            IsReply = request.IsReply,
            CommentOwnerId = request.CommentOwnerId,
        };

        _unitOfWork.PostComments.Update(entity);
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
        var entity = await _unitOfWork.PostComments.GetPostCommentByIdAsync(request.Id);

        if (entity == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostComment>.NotFoundError("id"));
        }

        _unitOfWork.PostComments.Remove(entity);
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
        var entity = await _unitOfWork.PostComments.GetPostCommentByIdAsync(request.PostCommentId);
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
        var entityList = await _unitOfWork.PostComments.GetPostCommentsByFilterAsync(filter: request.Filter);
        if (entityList == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostComment>.DuplicateError("filter"));
        }

        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: _mapper.Map<List<PostCommentModel>>(entityList));
    }
}

#endregion


#region PostIssueComment

public class CreatePostIssueCommentHandler : IRequestHandler<CreatePostIssueCommentCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePostIssueCommentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(CreatePostIssueCommentCommand request, CancellationToken cancellationToken)
    {


        var entity = new PostIssueComment()
        {
            ReplyToCommentId = request.ReplyToCommentId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            CreatorId = request.RequestInfo.UserId,
            CommentText = request.CommentText,
            PostIssueId = request.PostIssueId,
            IsReply = request.IsReply,
            CommentOwnerId = request.CommentOwnerId,
        };

        await _unitOfWork.PostIssueComments.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class UpdatePostIssueCommentHandler : IRequestHandler<UpdatePostIssueCommentCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePostIssueCommentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(UpdatePostIssueCommentCommand request, CancellationToken cancellationToken)
    {

        var entity = new PostIssueComment()
        {
            Id = request.Id,
            ReplyToCommentId = request.ReplyToCommentId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            UpdaterId = request.RequestInfo.UserId,
            CommentText = request.CommentText,
            PostIssueId = request.PostIssueId,
            IsReply = request.IsReply,
            CommentOwnerId = request.CommentOwnerId,
        };

        _unitOfWork.PostIssueComments.Update(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class DeletePostIssueCommentHandler : IRequestHandler<DeletePostIssueCommentCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePostIssueCommentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(DeletePostIssueCommentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PostIssueComments.GetPostIssueCommentByIdAsync(request.Id);

        if (entity == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostIssueComment>.NotFoundError("id"));
        }

        _unitOfWork.PostIssueComments.Remove(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class GetPostIssueCommentByIdHandler : IRequestHandler<GetPostIssueCommentByIdQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetPostIssueCommentByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetPostIssueCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PostIssueComments.GetPostIssueCommentByIdAsync(request.PostIssueId);
        if (entity == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostIssueComment>.NotFoundError("id"));
        }

        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: _mapper.Map<PostIssueCommentModel>(entity));
    }
}

public class GetPostIssueCommentByFilterHandler : IRequestHandler<GetPostIssueCommentByFilterQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPostIssueCommentByFilterHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetPostIssueCommentByFilterQuery request, CancellationToken cancellationToken)
    {
        var entityList = await _unitOfWork.PostIssueComments.GetPostIssueCommentsByFilterAsync(filter: request.Filter);
        if (entityList == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostIssueComment>.DuplicateError("filter"));
        }

        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: _mapper.Map<List<PostIssueCommentModel>>(entityList));
    }
}

#endregion


#region PostCategoryIssueComment

public class CreatePostCategoryIssueCommentHandler : IRequestHandler<CreatePostCategoryIssueCommentCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePostCategoryIssueCommentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(CreatePostCategoryIssueCommentCommand request, CancellationToken cancellationToken)
    {


        var entity = new PostCategoryIssueComment()
        {
            ReplyToCommentId = request.ReplyToCommentId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            CreatorId = request.RequestInfo.UserId,
            CommentText = request.CommentText,
            PostCategoryIssueId = request.PostCategoryIssueId,
            IsReply = request.IsReply,
            CommentOwnerId = request.CommentOwnerId,
        };

        await _unitOfWork.PostCategoryIssueComments.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class UpdatePostCategoryIssueCommentHandler : IRequestHandler<UpdatePostCategoryIssueCommentCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePostCategoryIssueCommentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(UpdatePostCategoryIssueCommentCommand request, CancellationToken cancellationToken)
    {

        var entity = new PostCategoryIssueComment()
        {
            Id = request.Id,
            ReplyToCommentId = request.ReplyToCommentId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            UpdaterId = request.RequestInfo.UserId,
            CommentText = request.CommentText,
            PostCategoryIssueId = request.PostCategoryIssueId,
            IsReply = request.IsReply,
            CommentOwnerId = request.CommentOwnerId,
        };

        _unitOfWork.PostCategoryIssueComments.Update(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class DeletePostCategoryIssueCommentHandler : IRequestHandler<DeletePostCategoryIssueCommentCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePostCategoryIssueCommentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(DeletePostCategoryIssueCommentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PostCategoryIssueComments.GetPostCategoryIssueCommentByIdAsync(request.Id);

        if (entity == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostCategoryIssueComment>.NotFoundError("id"));
        }

        _unitOfWork.PostCategoryIssueComments.Remove(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class GetPostCategoryIssueCommentByIdHandler : IRequestHandler<GetPostCategoryIssueCommentByIdQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetPostCategoryIssueCommentByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetPostCategoryIssueCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PostCategoryIssueComments.GetPostCategoryIssueCommentByIdAsync(request.PostCategoryIssueId);
        if (entity == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostCategoryIssueComment>.NotFoundError("id"));
        }

        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: _mapper.Map<PostCategoryIssueCommentModel>(entity));
    }
}

public class GetPostCategoryIssueCommentByFilterHandler : IRequestHandler<GetPostCategoryIssueCommentByFilterQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPostCategoryIssueCommentByFilterHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetPostCategoryIssueCommentByFilterQuery request, CancellationToken cancellationToken)
    {
        var entityList = await _unitOfWork.PostCategoryIssueComments.GetPostCategoryIssueCommentsByFilterAsync(filter: request.Filter);
        if (entityList == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostCategoryIssueComment>.DuplicateError("filter"));
        }

        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: _mapper.Map<List<PostCategoryIssueCommentModel>>(entityList));
    }
}

#endregion
