using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.Blog.Comments.PostCategoryComments;


public class CreatePostCategoryCommentCommandValidator : AbstractValidator<CreatePostCategoryCommentCommand>
{
    public CreatePostCategoryCommentCommandValidator()
    {
        //RuleFor(x => x.CommentText)
        //    .NotEmpty()
        //    .WithState(_ => co.InvalidPermissionIdValidationError);

        //RuleFor(x => x.Title)
        //    .MaximumLength(Defaults.NameLength)
        //    .WithState(_ => CommonErrors.InvalidTitleValidationError);

        //RuleFor(x => x.Title)
        //    .NotEmpty()
        //    .WithState(_ => CommonErrors.InvalidTitleValidationError);
    }
}