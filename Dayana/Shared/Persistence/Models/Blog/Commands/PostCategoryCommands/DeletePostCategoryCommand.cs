using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Blog.Commands.Blog.PostCategoryCommands;



public class DeletePostCategoryCommandValidator : AbstractValidator<DeletePostCategoryCommand>
{
    public DeletePostCategoryCommandValidator()
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