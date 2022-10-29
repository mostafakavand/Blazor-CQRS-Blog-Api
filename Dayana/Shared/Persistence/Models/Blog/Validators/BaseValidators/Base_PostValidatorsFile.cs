using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Blog.Base;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Blog.Validators.BaseValidators;
public class PostModelValidator : AbstractValidator<PostModel>
{
    public PostModelValidator()
    {
        RuleFor(x => x.PostTitle)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("title"));

        RuleFor(x => x.PostBody)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("body"));

        RuleFor(x => x.PostWriterId)
            .NotNull()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("writer id"));

        RuleFor(x => x.Subject)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("subject"));

        RuleFor(x => x.PostCategoryId)
            .NotNull()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("Category id"));

        RuleFor(x => x.Summery)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("Summery"));

        RuleFor(x => x.CreatedAt)
            .NotNull()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("create time"));


        RuleFor(x => x.CreatedAt)
            .NotNull()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("update time"));

    }
}


public class PostCategoryModelValidator : AbstractValidator<PostCategoryModel>
{
    public PostCategoryModelValidator()
    {
        RuleFor(x => x.CategoryIcon)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("post category icon"));

        RuleFor(x => x.CategorySubject)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("post category subject"));

        RuleFor(x => x.CategoryTitle)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("post Category title"));

        RuleFor(x => x.CreatedAt)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("create time"));
        RuleFor(x => x.UpdatedAt)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("update time"));

    }
}