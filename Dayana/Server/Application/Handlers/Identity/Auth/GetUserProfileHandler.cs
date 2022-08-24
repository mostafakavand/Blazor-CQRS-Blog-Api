using AutoMapper;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
using Dayana.Shared.Persistence.Models.Identity.Base.Users;
using Dayana.Shared.Persistence.Models.Identity.Queries.Auth;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Auth;

internal class GetUserProfileHandler : IRequestHandler<GetUserProfileQuery, OperationResult>
{
    private readonly IUnitOfWorkIdentity _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserProfileHandler(IUnitOfWorkIdentity unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetUserByIdAsync(request.UserId);
        if (user == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: UserErrors.UserNotFoundError);

        var model = _mapper.Map<UserModel>(user);

        return new OperationResult(OperationResultStatus.Ok, value: model);
    }
}