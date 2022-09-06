using AutoMapper;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Base;
using Dayana.Shared.Persistence.Models.Identity.Queries;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity;

public class GetPermissionsByFilterHandler : IRequestHandler<GetPermissionsByFilterQuery, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;
    private readonly IMapper _mapper;

    public GetPermissionsByFilterHandler(IUnitOfWorkIdentity unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetPermissionsByFilterQuery request, CancellationToken cancellationToken)
    {
        var entities = await _unitOfWork.Permissions.GetPermissionsByFilterAsync(request.Filter);

        var models = _mapper.Map<List<PermissionModel>>(entities);

        var result = new PaginatedList<PermissionModel>
        {
            Page = request.Filter.Page,
            PageSize = request.Filter.PageSize,
            Data = models,
            TotalCount = models.Count()
        };

        return new OperationResult(OperationResultStatus.Ok, value: result);
    }
}