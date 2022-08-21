using AutoMapper;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Base.Roles;
using Dayana.Shared.Persistence.Models.Identity.Queries.Roles;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Roles;

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
            return new OperationResult(OperationResultStatus.UnProcessable, value: RoleErrors.RoleNotFoundError);
        var model = new RoleModel();
        model = _mapper.Map<RoleModel>(entity);

        return new OperationResult(OperationResultStatus.Ok, value: model);
    }
}