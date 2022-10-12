using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using Dayana.Shared.Persistence.Models.Identity.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Validators.CommandValidators;

#region Post comment

public class CreatePostCommentCommandValidator : AbstractValidator<CreatePostCommentCommand>
{
    public CreatePostCommentCommandValidator()
    {
        RuleFor(x => x.CommentText)
            .NotEmpty()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("text"));

        RuleFor(x => x.PostId)
            .NotNull()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("post id"));

        RuleFor(x => x.CommentOwnerId)
            .NotEmpty()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("writer id"));
    }
}

public class UpdatePostCommentCommandValidator : AbstractValidator<UpdatePostCommentCommand>
{
    public UpdatePostCommentCommandValidator()
    {
        RuleFor(x => x.CommentText)
            .NotEmpty()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("text"));

        RuleFor(x => x.PostId)
            .NotNull()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("post id"));

        RuleFor(x => x.CommentOwnerId)
            .NotEmpty()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("writer id"));
    }
}

public class DeletePostCommentCommandValidator : AbstractValidator<DeletePostCommentCommand>
{
    public DeletePostCommentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("id"));
    }
}


#endregion

#region Post Category comment
public class CreatePostCategoryCommentCommandValidator : AbstractValidator<CreatePostCategoryCommentCommand>
{
    public CreatePostCategoryCommentCommandValidator()
    {
        RuleFor(x => x.CommentText)
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("text"));

        RuleFor(x => x.PostCategoryId)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("post category id"));

        RuleFor(x => x.CommentOwnerId)
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("writer id"));
    }
}

public class UpdatePostCategoryCommentCommandValidator : AbstractValidator<UpdatePostCategoryCommentCommand>
{
    public UpdatePostCategoryCommentCommandValidator()
    {
        RuleFor(x => x.CommentText)
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("text"));

        RuleFor(x => x.PostCategoryId)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("post category id"));

        RuleFor(x => x.CommentOwnerId)
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("writer id"));
    }
}

public class DeletePostCategoryCommentCommandValidator : AbstractValidator<DeletePostCategoryCommentCommand>
{
    public DeletePostCategoryCommentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("id"));
    }
}

#endregion