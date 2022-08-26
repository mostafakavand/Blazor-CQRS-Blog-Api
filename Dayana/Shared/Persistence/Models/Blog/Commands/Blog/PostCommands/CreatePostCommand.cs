using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Identity.Commands.Roles;
using FluentValidation;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.Blog.PostCommands;

public class CreatePostCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreatePostCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public string Title { get; set; }
    public string Summery { get; set; }
    public string TextContent { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
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