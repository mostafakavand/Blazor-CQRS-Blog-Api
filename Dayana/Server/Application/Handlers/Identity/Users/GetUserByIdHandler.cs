using AutoMapper;
using Dayana.Server.Application.Errors.Identity;
using MediatR;

namespace Dayana.Server.Application.Handlers.Identity.Users;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
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