using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Blog.Validators.CommandValidators;


#region post
public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("title"));

        RuleFor(x => x.TextContent)
            .NotNull()
            .NotNull()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("text content"));

        RuleFor(x => x.Summery)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("summery"));
    }
}

public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostCommandValidator()
    {
        RuleFor(x => x.Id)
         .NotNull()
         .NotEmpty()
         .WithState(_ => GenericErrors<Post>.InvalidVariableError("id"));

        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("title"));

        RuleFor(x => x.TextContent)
            .NotNull()
            .NotNull()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("text content"));

        RuleFor(x => x.Summery)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("summery"));
    }
}

public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
{
    public DeletePostCommandValidator()
    {
        RuleFor(x => x.Id)
         .NotNull()
         .NotEmpty()
         .WithState(_ => GenericErrors<Post>.InvalidVariableError("id"));
    }
}

#endregion

#region post category
public class CreatePostCategoryCommandValidator : AbstractValidator<CreatePostCategoryCommand>
{
    public CreatePostCategoryCommandValidator()
    {
        RuleFor(x => x.CategoryIcon)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("icon"));

        RuleFor(x => x.CategoryTitle)
            .NotNull()
            .NotNull()
            .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("title"));
    }
}

public class UpdatePostCategoryCommandValidator : AbstractValidator<UpdatePostCategoryCommand>
{
    public UpdatePostCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
         .NotNull()
         .NotEmpty()
         .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("id"));

        RuleFor(x => x.CategoryIcon)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("icon"));

        RuleFor(x => x.CategoryTitle)
            .NotNull()
            .NotNull()
            .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("title"));
    }
}

public class DeletePostCategoryCommandValidator : AbstractValidator<DeletePostCategoryCommand>
{
    public DeletePostCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
         .NotNull()
         .NotEmpty()
         .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("id"));
    }
}

#endregion