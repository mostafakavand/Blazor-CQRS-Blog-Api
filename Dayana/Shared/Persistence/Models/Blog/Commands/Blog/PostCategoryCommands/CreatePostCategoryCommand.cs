using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Identity.Commands.Roles;
using FluentValidation;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.Blog.PostCategoryCommands;

public class CreatePostCategoryCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreatePostCategoryCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public string CategoryTitle { get; set; }
    public string CategoryIcon { get; set; }

    public RequestInfo RequestInfo { get; set; }
}

public class CreatePostCategoryCommandValidator : AbstractValidator<CreatePostCategoryCommand>
{
    public CreatePostCategoryCommandValidator()
    {
        //RuleFor(x => x.PermissionIds)
        //    .NotEmpty()
        //    .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);

        //RuleFor(x => x.Title)
        //    .MaximumLength(Defaults.NameLength)
        //    .WithState(_ => CommonErrors.InvalidTitleValidationError);

        //RuleFor(x => x.Title)
        //    .NotEmpty()
        //    .WithState(_ => CommonErrors.InvalidTitleValidationError);
    }
}