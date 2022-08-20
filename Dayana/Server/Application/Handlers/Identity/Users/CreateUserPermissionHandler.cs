using Dayana.Shared.Infrastructure.Errors.Identity;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Users;

public class CreateUserPermissionHandler : IRequestHandler<CreateUserPermissionCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserPermissionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(CreateUserPermissionCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.Claims
            .ExistsAsync(new DuplicateClaimSpecification(request.PermissionId, request.UserId, ClaimType.Permission).ToExpression());

        if (isExist)
            return new OperationResult(OperationResultStatus.UnProcessable, value: PermissionErrors.DuplicateClaimError);

        var entity = ClaimHelper.CreateClaim(request);

        _unitOfWork.Claims.Add(entity);

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}