using Dayana.Server.Application.Specifications.Identity.Claims;
using Dayana.Shared.Basic.MethodsAndObjects.Helpers;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Commands.Users;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Users;

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
            .ExistsAsync(new DuplicateClaimSpecification(request.PermissionId, request.UserId).ToExpression());

        if (isExist)
            return new OperationResult(OperationResultStatus.UnProcessable, value: PermissionErrors.DuplicateClaimError);

        var entity = ClaimHelper.CreateClaim(request);

        _unitOfWork.Claims.Add(entity);

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}