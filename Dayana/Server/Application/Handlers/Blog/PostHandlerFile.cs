using AutoMapper;
using Dayana.Server.Application.Specifications.Blog;
using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Blog.Base;
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
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Post>.DuplicateError("Post name"));
        }

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
            CreatorId = request.RequestInfo.UserId,
        };

        await _unitOfWork.BlogPosts.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
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
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Post>.DuplicateError("Post name"));
        }
        var data = await _unitOfWork.BlogPosts.GetPostByIdAsync(request.Id);
        var entity = new Post()
        {
            Id = request.Id,
            PostTitle = request.Title,
            PostBody = request.TextContent,
            PostCategoryId = request.PostCategoryId,
            PostWriterId = request.RequestInfo.UserId,
            Subject = request.Subject,
            Summary = request.Summery,
            UpdatedAt = DateTime.UtcNow,
            UpdaterId = request.RequestInfo.UserId,
            //-------------------------//
            CreatedAt = data.CreatedAt,
            CreatorId = data.CreatorId
        };

        _unitOfWork.BlogPosts.Update(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
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

        if (entity == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Post>.NotFoundError("id"));
        }

        _unitOfWork.BlogPosts.Remove(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetPostByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.BlogPosts.GetPostByIdAsync(request.PostId);
        if (entity == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Post>.NotFoundError("id"));
        }

        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: _mapper.Map<PostModel>(entity));
    }
}

public class GetPostByFilterHandler : IRequestHandler<GetPostByFilterQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPostByFilterHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetPostByFilterQuery request, CancellationToken cancellationToken)
    {
        var entityList = await _unitOfWork.BlogPosts.GetPostsByFilterAsync(filter: request.Filter);
        if (entityList == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable,
                value: GenericErrors<PostCategory>.NotFoundError("filter"));
        }

        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: _mapper.Map<List<PostModel>>(entityList));
    }
}

#endregion

#region PostCategory

public class CreatePostCategoryHandler : IRequestHandler<CreatePostCategoryCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePostCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(CreatePostCategoryCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.BlogPostCategories
            .ExistsAsync(new DuplicatePostCategorySpecification(request.CategoryTitle).ToExpression());

        if (isExist)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostCategory>.DuplicateError("PostCategory name"));
        }

        var entity = new PostCategory()
        {
            CategoryTitle = request.CategoryTitle,
            CategoryIcon = request.CategoryTitle,
            CategorySubject = request.CategorySubject,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            CreatorId = request.RequestInfo.UserId,
        };

        await _unitOfWork.BlogPostCategories.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}

public class UpdatePostCategoryHandler : IRequestHandler<UpdatePostCategoryCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePostCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(UpdatePostCategoryCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.BlogPostCategories
            .ExistsAsync(new DuplicatePostCategorySpecification(request.CategoryTitle).ToExpression());

        if (isExist)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostCategory>.DuplicateError("PostCategory name"));
        }
        var data = await _unitOfWork.BlogPostCategories.GetPostCategoryByIdAsync(request.Id);
        var entity = new PostCategory()
        {
            Id = request.Id,
            CategoryTitle = request.CategoryTitle,
            CategoryIcon = request.CategoryTitle,
            CategorySubject = request.CategorySubject,
            UpdatedAt = DateTime.UtcNow,
            UpdaterId = request.RequestInfo.UserId,
            //-------------------------//
            CreatedAt = data.CreatedAt,
            CreatorId = data.CreatorId
        };

        _unitOfWork.BlogPostCategories.Update(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class DeletePostCategoryHandler : IRequestHandler<DeletePostCategoryCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePostCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(DeletePostCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.BlogPostCategories.GetPostCategoryByIdAsync(request.Id);

        if (entity == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostCategory>.NotFoundError("id"));
        }

        _unitOfWork.BlogPostCategories.Remove(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class GetPostCategoryByIdHandler : IRequestHandler<GetPostCategoryByIdQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPostCategoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetPostCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.BlogPostCategories.GetPostCategoryByIdAsync(request.Id);
        if (entity == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostCategory>.NotFoundError("id"));
        }

        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: _mapper.Map<PostCategory>(entity));
    }
}

public class GetPostCategoryByFilterHandler : IRequestHandler<GetPostCategoryByFilterQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPostCategoryByFilterHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetPostCategoryByFilterQuery request, CancellationToken cancellationToken)
    {
        var entityList = await _unitOfWork.BlogPostCategories.GetPostCategoriesByFilterAsync(filter: request.Filter);
        if (entityList == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostCategory>.NotFoundError("filter"));
        }

        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: _mapper.Map<List<PostCategoryModel>>(entityList));
    }
}

#endregion
