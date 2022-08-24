using AutoMapper;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Base.Roles;
using Dayana.Shared.Persistence.Models.Identity.Filters.Roles;
using Dayana.Shared.Persistence.Models.Identity.Queries.Roles;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Roles;

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
        request.Filter.Include = new RoleIncludes { Permission = true };

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