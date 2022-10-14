using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        RuleFor(x => x.Summery)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("summery"));

        RuleFor(x => x.TextContent)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("text content"));
    }
}

public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostCommandValidator()
    {

        RuleFor(x => x.Id)
         .NotNull()
         .NotEmpty()
         .GreaterThan(0)
         .WithState(_ => GenericErrors<Post>.InvalidVariableError("Id"));

        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("title"));

        RuleFor(x => x.Summery)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("summery"));

        RuleFor(x => x.TextContent)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("text content"));
    }
}

public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
{
    public DeletePostCommandValidator()
    {

        RuleFor(x => x.Id)
          .NotNull()
          .NotEmpty()
          .GreaterThan(0)
          .WithState(_ => GenericErrors<Post>.InvalidVariableError("Id"));
    }
}
#endregion



#region post Category
public class CreatePostCategoryCommandValidator : AbstractValidator<CreatePostCategoryCommand>
{
    public CreatePostCategoryCommandValidator()
    {
        RuleFor(x => x.CategoryTitle)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("title"));

        RuleFor(x => x.CategoryIcon)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("icon"));
    }
}

public class UpdatePostCategoryCommandValidator : AbstractValidator<UpdatePostCategoryCommand>
{
    public UpdatePostCategoryCommandValidator()
    {

        RuleFor(x => x.Id)
         .NotNull()
         .NotEmpty()
         .GreaterThan(0)
         .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("Id"));

        RuleFor(x => x.CategoryTitle)
                  .NotNull()
                  .NotEmpty()
                  .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("title"));

        RuleFor(x => x.CategoryIcon)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("icon"));
    }
}

public class DeletePostCategoryCommandValidator : AbstractValidator<DeletePostCategoryCommand>
{
    public DeletePostCategoryCommandValidator()
    {

        RuleFor(x => x.Id)
          .NotNull()
          .NotEmpty()
          .GreaterThan(0)
          .WithState(_ => GenericErrors<Post>.InvalidVariableError("Id"));
    }
}
#endregion
