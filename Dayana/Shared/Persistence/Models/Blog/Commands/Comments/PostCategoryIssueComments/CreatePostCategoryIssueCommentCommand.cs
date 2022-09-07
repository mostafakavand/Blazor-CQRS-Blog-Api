using Dayana.Shared.Persistence.Models.Blog.Commands.Blog.Comments.PostCategoryComments;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.Blog.Comments.PostCategoryIssueComments;


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