using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using MediatR;

namespace Dayana.Server.Application.Behaviors.Identity.Common;

public class CommitBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, OperationResult> where TRequest : IRequest<OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;

    public CommitBehavior(IUnitOfWorkIdentity unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<OperationResult> next)
    {
        var operation = await next();

        if (operation.IsPersistAble)
            _ = await _unitOfWork.CommitAsync();

        return operation;
    }
}