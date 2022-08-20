using AutoMapper;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Users;

public class GetUsersByFilterHandler : IRequestHandler<GetUsersByFilterQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUsersByFilterHandler(IUnitOfWork unitOfWork, IMapper mapper)
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