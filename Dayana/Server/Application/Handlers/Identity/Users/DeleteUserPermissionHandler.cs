using Dayana.Shared.Infrastructure.Errors.Identity;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Users;

public class DeleteUserPermissionHandler : IRequestHandler<DeleteUserPermissionCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserPermissionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(DeleteUserPermissionCommand request, CancellationToken cancellationToken)
    {

        var entity = await _unitOfWork.Claims.GetClaimByIdAsync(request.ClaimId);

        if (entity == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: PermissionErrors.ClaimNotFoundError);

        entity.UpdatedAt = DateTime.UtcNow;
        _unitOfWork.Claims.Update(entity);

        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}