using AutoMapper;
using Dayana.Server.Application.Specifications.Identity;
using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Base;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using Dayana.Shared.Persistence.Models.Identity.Queries;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity;


public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public CreateRoleHandler(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.Roles
            .ExistsAsync(new DuplicateRoleSpecificationFile(request.Title).ToExpression());

        if (isExist)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Role>.NotFoundError("title"));

        var entity = RoleHelper.CreateRole(request);

        _unitOfWork.Roles.Add(entity);

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}


public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public DeleteRoleHandler(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Roles.GetRoleByIdAsync(request.RoleId);

        if (entity == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Role>.NotFoundError("role id"));

        entity.UpdatedAt = DateTime.Now;
        _unitOfWork.Roles.Update(entity); ;

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}


public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;
    private readonly IMapper _mapper;

    public GetRoleByIdHandler(IUnitOfWorkIdentity unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Roles.GetRoleByIdAsync(request.RoleId);

        if (entity == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Role>.NotFoundError("role id"));
        _ = new RoleModel();
        RoleModel? model = _mapper.Map<RoleModel>(entity);

        return new OperationResult(OperationResultStatus.Ok, value: model);
    }
}


public class GetRolesByFilterHandler : IRequestHandler<GetRolesByFilterQuery, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;
    private readonly IMapper _mapper;

    public GetRolesByFilterHandler(IUnitOfWorkIdentity unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetRolesByFilterQuery request, CancellationToken cancellationToken)
    {
        //request.Filter.Include = new RoleIncludes { Permission = true };

        var entities = await _unitOfWork.Roles.GetRolesByFilterAsync(request.Filter);

        var models = _mapper.Map<List<RoleModel>>(entities);

        var result = new PaginatedList<RoleModel>
        {
            Page = request.Filter.Page,
            PageSize = request.Filter.PageSize,
            Data = models,
            TotalCount = models.Count()
        };

        return new OperationResult(OperationResultStatus.Ok, value: result);
    }
}


public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public UpdateRoleHandler(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _unitOfWork.Roles.GetRoleByIdAsync(request.RoleId);

        if (role == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Role>.NotFoundError("role id"));

        var isExist = await _unitOfWork.Roles
            .ExistsAsync(new DuplicateRoleSpecificationFile(request.Title).ToExpression());

        if (isExist && role.Title != request.Title)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Role>.DuplicateError("title"));

        // Update
        role.Title = request.Title;
        role.RolePermission = request.PermissionIds.Distinct()
            .Select(x => RoleHelper.CreateRolePermission(x, request.RequestInfo.UserId, request.RoleId)).ToList();

        role.UpdatedAt = DateTime.Now;

        _unitOfWork.Roles.Update(role);

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: role);
    }
}