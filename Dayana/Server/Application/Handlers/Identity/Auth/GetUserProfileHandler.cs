using AutoMapper;
using Dayana.Shared.Infrastructure.Errors.Identity;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Auth;

internal class GetUserProfileHandler : IRequestHandler<GetUserProfileQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserProfileHandler(IUnitOfWork unitOfWork, IMapper mapper)
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