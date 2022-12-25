using AutoMapper;
using Dayana.Server.Application.Specifications.Blog;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Blog.Base;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using Dayana.Shared.Persistence.Models.Blog.Queries;
using MediatR;

namespace Dayana.Server.Application.Handlers.Blog;

#region PostIssue

public class CreatePostIssueHandler : IRequestHandler<CreatePostIssueCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePostIssueHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(CreatePostIssueCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.PostIssues
            .ExistsAsync(new DuplicatePostIssueSpecification(request.IssueTitle).ToExpression());

        if (isExist)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostIssue>.DuplicateError("PostIssue name"));
        }

        var entity = new PostIssue()
        {
            IssueDescription = request.IssueDescription,
            IssueTitle = request.IssueTitle,
            PostId = request.PostId,
            IssueWriterId = request.RequestInfo.UserId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            CreatorId = request.RequestInfo.UserId,
        };

        await _unitOfWork.PostIssues.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class UpdatePostIssueHandler : IRequestHandler<UpdatePostIssueCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePostIssueHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(UpdatePostIssueCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.PostIssues
            .ExistsAsync(new DuplicatePostIssueSpecification(request.IssueTitle).ToExpression());

        if (isExist)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostIssue>.DuplicateError("PostIssue name"));
        }
        var data = await _unitOfWork.PostIssues.GetPostIssueByIdAsync(request.PosIssueId);
        var entity = new PostIssue()
        {
            Id = request.PosIssueId,
            IssueDescription = request.IssueDescription,
            IssueTitle = request.IssueTitle,
            PostId = request.PostId,
            IssueWriterId = request.RequestInfo.UserId,
            UpdatedAt = DateTime.UtcNow,
            UpdaterId = request.RequestInfo.UserId,
            //------------------------//
            CreatedAt = data.CreatedAt,
            CreatorId = data.CreatorId,
        };

        _unitOfWork.PostIssues.Update(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class DeletePostIssueHandler : IRequestHandler<DeletePostIssueCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePostIssueHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(DeletePostIssueCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PostIssues.GetPostIssueByIdAsync(request.Id);

        if (entity == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostIssue>.NotFoundError("id"));
        }

        _unitOfWork.PostIssues.Remove(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class GetPostIssueByIdHandler : IRequestHandler<GetPostIssueByIdQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetPostIssueByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetPostIssueByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PostIssues.GetPostIssueByIdAsync(request.PostIssueId);
        if (entity == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostIssue>.NotFoundError("id"));
        }

        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: _mapper.Map<PostIssueModel>(entity));
    }
}

public class GetPostIssueByFilterHandler : IRequestHandler<GetPostIssueByFilterQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPostIssueByFilterHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetPostIssueByFilterQuery request, CancellationToken cancellationToken)
    {
        var entityList = await _unitOfWork.PostIssues.GetPostIssuesByFilterAsync(filter: request.Filter);
        if (entityList == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostCategoryIssue>.NotFoundError("filter"));
        }

        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: _mapper.Map<List<PostIssueModel>>(entityList));
    }
}

#endregion

#region PostCategoryIssue

public class CreatePostCategoryIssueHandler : IRequestHandler<CreatePostCategoryIssueCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePostCategoryIssueHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(CreatePostCategoryIssueCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.PostCategoryIssues
            .ExistsAsync(new DuplicatePostCategoryIssueSpecification(request.IssueTitle).ToExpression());

        if (isExist)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostCategoryIssue>.DuplicateError("PostCategoryIssue name"));
        }

        var entity = new PostCategoryIssue()
        {
            IssueDescription = request.IssueDescription,
            IssueTitle = request.IssueTitle,
            PostCategoryId = request.PostCategoryId,
            IssueWriterId = request.RequestInfo.UserId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            CreatorId = request.RequestInfo.UserId,
        };

        await _unitOfWork.PostCategoryIssues.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class UpdatePostCategoryIssueHandler : IRequestHandler<UpdatePostCategoryIssueCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePostCategoryIssueHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(UpdatePostCategoryIssueCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.PostCategoryIssues
            .ExistsAsync(new DuplicatePostCategoryIssueSpecification(request.IssueTitle).ToExpression());

        if (isExist)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostCategoryIssue>.DuplicateError("PostCategoryIssue name"));
        }
        var data = await _unitOfWork.PostCategoryIssues.GetPostCategoryIssueByIdAsync(request.Id);
        var entity = new PostCategoryIssue()
        {
            Id = request.Id,
            IssueDescription = request.IssueDescription,
            IssueTitle = request.IssueTitle,
            PostCategoryId = request.PostCategoryId,
            IssueWriterId = request.RequestInfo.UserId,
            UpdatedAt = DateTime.UtcNow,
            UpdaterId = request.RequestInfo.UserId,
            //------------------------//
            CreatedAt = data.CreatedAt,
            CreatorId = data.CreatorId,
        };

        _unitOfWork.PostCategoryIssues.Update(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class DeletePostCategoryIssueHandler : IRequestHandler<DeletePostCategoryIssueCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePostCategoryIssueHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(DeletePostCategoryIssueCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PostCategoryIssues.GetPostCategoryIssueByIdAsync(request.Id);

        if (entity == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostCategoryIssue>.NotFoundError("id"));
        }

        _unitOfWork.PostCategoryIssues.Remove(entity);
        await _unitOfWork.CommitAsync();
        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true);
    }
}

public class GetPostCategoryIssueByIdHandler : IRequestHandler<GetPostCategoryIssueByIdQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetPostCategoryIssueByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetPostCategoryIssueByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.PostCategoryIssues.GetPostCategoryIssueByIdAsync(request.Id);
        if (entity == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostCategoryIssue>.NotFoundError("id"));
        }

        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: _mapper.Map<PostCategoryIssueModel>(entity));
    }
}

public class GetPostCategoryIssueByFilterHandler : IRequestHandler<GetPostCategoryIssueByFilterQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPostCategoryIssueByFilterHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetPostCategoryIssueByFilterQuery request, CancellationToken cancellationToken)
    {
        var entityList = await _unitOfWork.PostCategoryIssues.GetPostCategoryIssuesByFilterAsync(filter: request.Filter);
        if (entityList == null)
        {
            _unitOfWork.Dispose();
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<PostCategoryIssue>.NotFoundError("filter"));
        }

        _unitOfWork.Dispose();
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: _mapper.Map<List<PostCategoryIssueModel>>(entityList));
    }
}

#endregion
