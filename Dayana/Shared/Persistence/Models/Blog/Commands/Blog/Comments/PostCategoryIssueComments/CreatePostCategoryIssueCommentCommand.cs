using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Blog.Commands.Blog.Comments.PostCategoryComments;
using FluentValidation;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.Blog.Comments.PostCategoryIssueComments;
public class CreatePostCategoryIssueCommentCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreatePostCategoryIssueCommentCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public RequestInfo RequestInfo { get; set; }

    public string CommentText { get; set; }
    public bool IsReply { get; set; }
    public int PostCategoryIssueId { get; set; }
    public int CommentOwnerId { get; set; }
    public int? ReplyToCommentId { get; set; }
}

public class UpdatePostCategoryCommentCommandValidatorValidator : AbstractValidator<UpdatePostCategoryCommentCommandValidator>
{
    public UpdatePostCategoryCommentCommandValidatorValidator()
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