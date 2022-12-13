﻿namespace Dayana.Server.Application.Handlers.Blog;

//public class CreatePostHandler : IRequestHandler<CreatePostCommand, OperationResult>
//{
//    private readonly IUnitOfWorkIdentity _unitOfWork;

//    public CreatePostHandler(IUnitOfWorkIdentity unitOfWork)
//    {
//        _unitOfWork = unitOfWork;
//    }

//    public async Task<OperationResult> Handle(CreatePostCommand request, CancellationToken cancellationToken)
//    {
//        var isExist = await _unitOfWork.Posts
//            .ExistsAsync(new DuplicatePostSpecification(request.Postname).ToExpression());

//        if (isExist)
//            return new OperationResult(OperationResultStatus.UnProcessable, value: GenericErrors<Post>.DuplicateError("Post name"));

//        var entity = new Post()
//        {
//            Postname = request.Postname,
//            Mobile = request.Mobile,
//            Email = request.Email,
//            PasswordHash = PasswordHasher.Hash(request.Password),
//            State = request.State,
//            CreatedAt = request.CreatedAt,
//            UpdatedAt = request.UpdatedAt,
//            ConcurrencyStamp = StampGenerator.CreateSecurityStamp(Defaults.SecurityStampLength),
//            SecurityStamp = StampGenerator.CreateSecurityStamp(Defaults.SecurityStampLength),
//        };

//        _unitOfWork.Posts.Add(entity);

//        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
//    }
//}