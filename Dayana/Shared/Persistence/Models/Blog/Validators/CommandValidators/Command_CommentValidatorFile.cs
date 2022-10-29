using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using FluentValidation;

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

#region Post and Post Category Issue Comment Validator

public class CreatePostIssueCommentCommandValidator : AbstractValidator<CreatePostIssueCommentCommand>
{
    public CreatePostIssueCommentCommandValidator()
    {
        RuleFor(x => x.CommentText)
            .NotEmpty()
            .WithState(_ => GenericErrors<PostIssueComment>.InvalidVariableError("text"));

        RuleFor(x => x.PostIssueId)
            .NotNull()
            .WithState(_ => GenericErrors<PostIssueComment>.InvalidVariableError("post issue id"));

        RuleFor(x => x.CommentOwnerId)
            .NotEmpty()
            .WithState(_ => GenericErrors<PostIssueComment>.InvalidVariableError("writer id"));
    }
}

public class CreatePostCategoryIssueCommentCommandValidator : AbstractValidator<CreatePostCategoryIssueCommentCommand>
{
    public CreatePostCategoryIssueCommentCommandValidator()
    {
        RuleFor(x => x.CommentText)
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategoryIssueComment>.InvalidVariableError("text"));

        RuleFor(x => x.PostCategoryIssueId)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategoryIssueComment>.InvalidVariableError("post category issue id"));

        RuleFor(x => x.CommentOwnerId)
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategoryIssueComment>.InvalidVariableError("writer id"));
    }
}

#endregion
