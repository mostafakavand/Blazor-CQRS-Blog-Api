using Dayana.Server.Application.Specifications.Identity.Users;
using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Commands.Users;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Users;

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
            .ExistsAsync(new DuplicateUserSpecification(request.Username).ToExpression());

        if (isExist)
            return new OperationResult(OperationResultStatus.UnProcessable, value: UserErrors.DuplicateUsernameError);

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