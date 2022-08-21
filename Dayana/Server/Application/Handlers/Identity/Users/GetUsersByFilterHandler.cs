using AutoMapper;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Base.Users;
using Dayana.Shared.Persistence.Models.Identity.Filters.Users;
using Dayana.Shared.Persistence.Models.Identity.Queries.Users;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Users;

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
        request.Filter.Include = new UserIncludes { Role = true };

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