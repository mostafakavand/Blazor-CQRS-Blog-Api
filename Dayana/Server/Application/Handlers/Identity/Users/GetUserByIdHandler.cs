using AutoMapper;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Base.Users;
using Dayana.Shared.Persistence.Models.Identity.Queries.Users;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Users;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByIdHandler(IUnitOfWorkIdentity unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {

        var entity = await _unitOfWork.Users.GetUserByIdAsync(request.UserId);
        if (entity == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: UserErrors.UserNotFoundError);


        var model = _mapper.Map<List<UserModel>>(entity);

        return new OperationResult(OperationResultStatus.Ok, value: model);
    }
}