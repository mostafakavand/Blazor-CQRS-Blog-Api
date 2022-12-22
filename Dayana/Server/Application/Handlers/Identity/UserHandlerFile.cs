using AutoMapper;
using Dayana.Server.Application.Specifications.Identity;
using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Domains.Identity.Permissions;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Base;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using Dayana.Shared.Persistence.Models.Identity.Queries;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity;


public class CreateUserHandler : IRequestHandler<CreateUserCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public CreateUserHandler(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.Users
            .ExistsAsync(new DuplicateUserSpecificationFile(request.Username).ToExpression());

        if (isExist)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<User>.DuplicateError("user name"));

        var entity = new User()
        {
            Username = request.Username,
            Mobile = request.Mobile,
            Email = request.Email,
            PasswordHash = PasswordHasher.Hash(request.Password),
            State = request.State,
            CreatedAt = request.CreatedAt,
            UpdatedAt = request.UpdatedAt,
            ConcurrencyStamp = StampGenerator.CreateSecurityStamp(Defaults.SecurityStampLength),
            SecurityStamp = StampGenerator.CreateSecurityStamp(Defaults.SecurityStampLength),
        };

        _unitOfWork.Users.Add(entity);

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}


public class CreateUserPermissionHandler : IRequestHandler<CreateUserPermissionCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public CreateUserPermissionHandler(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(CreateUserPermissionCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.Claims
            .ExistsAsync(new DuplicateClaimSpecificationFile(request.PermissionId, request.UserId).ToExpression());

        if (isExist)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Permission>.NotFoundError("user Id and permission id"));

        var entity = ClaimHelper.CreateClaim(request);

        _unitOfWork.Claims.Add(entity);

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}


public class DeleteUserPermissionHandler : IRequestHandler<DeleteUserPermissionCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public DeleteUserPermissionHandler(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(DeleteUserPermissionCommand request, CancellationToken cancellationToken)
    {

        var entity = await _unitOfWork.Claims.GetClaimByIdAsync(request.ClaimId);

        if (entity == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Permission>.NotFoundError("claim Id"));

        entity.UpdatedAt = DateTime.UtcNow;
        _unitOfWork.Claims.Update(entity);

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}


public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByIdHandler(IUnitOfWorkIdentity unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {

        var entity = await _unitOfWork.Users.GetUserByIdAsync(request.UserId);
        if (entity == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<User>.NotFoundError("user Id"));


        var model = _mapper.Map<List<UserModel>>(entity);

        return new OperationResult(OperationResultStatus.Ok, value: model);
    }
}


public class GetUsersByFilterHandler : IRequestHandler<GetUsersByFilterQuery, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;
    private readonly IMapper _mapper;

    public GetUsersByFilterHandler(IUnitOfWorkIdentity unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetUsersByFilterQuery request, CancellationToken cancellationToken)
    {
        var entities = await _unitOfWork.Users.GetUsersByFilterAsync(request.Filter);

        var models = _mapper.Map<List<UserModel>>(entities);

        var result = new PaginatedList<UserModel>
        {
            Page = request.Filter.Page,
            PageSize = request.Filter.PageSize,
            Data = models,
            TotalCount = models.Count
        };

        return new OperationResult(OperationResultStatus.Ok, value: result);
    }
}


public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public UpdateUserHandler(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetUserByIdAsync(request.UserId);

        if (user == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<User>.NotFoundError("user id"));

        if (user.PasswordHash != PasswordHasher.Hash(request.Password))
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<User>.InvalidVariableError("password"));

        // Update
        user.Mobile = request.Mobile;
        user.Email = request.Email;
        user.Username = request.Username;
        if (user.Email != request.Email)
            user.IsEmailConfirmed = false;
        if (user.Mobile != request.Mobile)
            user.IsMobileConfirmed = false;

        _unitOfWork.Users.Update(user);

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: user);
    }
}
public class UpdateUserPasswordHandler : IRequestHandler<UpdateUserPasswordCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public UpdateUserPasswordHandler(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetUserByIdAsync(request.UserId);
        if (user == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<User>.NotFoundError("user id"));

        if (user.PasswordHash != PasswordHasher.Hash(request.LastPassword))
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<User>.InvalidVariableError("last password"));

        user.PasswordHash = PasswordHasher.Hash(request.NewPassword);

        user.UpdatedAt = DateTime.Now;

        _unitOfWork.Users.Update(user);

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: user);
    }
}


public class UpdateUserRolesHandler : IRequestHandler<UpdateUserRolesCommand, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public UpdateUserRolesHandler(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetUserByIdAsync(request.UserId);

        if (user == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<User>.NotFoundError("id"));

        if (user.UserRoles.Count == 0)
            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<User>.CustomError(causeOfError: "user hasn't enough role", variableName: "user role"));

        // Update
        if (request.RoleIds != null)
            user.UserRoles = request.RoleIds.Select(x => new UserRole
            {
                UserId = request.UserId,
                RoleId = x
            }).ToList();

        _unitOfWork.Users.Update(user);

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: user);
    }
}