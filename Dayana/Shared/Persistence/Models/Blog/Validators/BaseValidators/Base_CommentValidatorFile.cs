using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Blog.Base;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Blog.Validators.BaseValidators;


#region issue comments

public class PostCategoryIssueCommentModelValidator : AbstractValidator<PostCategoryIssueCommentModel>
{
    public PostCategoryIssueCommentModelValidator()
    {
        RuleFor(x => x.CommentOwnerId)
            .NotNull()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<PostCategoryIssueComment>.InvalidVariableError("comment writer id"));

        RuleFor(x => x.CommentText)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategoryIssueComment>.InvalidVariableError("comment text"));

        RuleFor(x => x.IsReply)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategoryIssueComment>.InvalidVariableError("is-reply"));

        RuleFor(x => x.PostCategoryIssueId)
          .NotNull()
          .GreaterThan(0)
          .WithState(_ => GenericErrors<PostCategoryIssueComment>.InvalidVariableError("post category issue id"));

        RuleFor(x => x.ReplyToCommentId)
          .NotNull()
          .When(x => x.IsReply == true)
          .GreaterThan(0)
          .WithState(_ => GenericErrors<PostCategoryIssueComment>.InvalidVariableError("reply to comment id"));

        RuleFor(x => x.CreatedAt)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategoryIssueComment>.InvalidVariableError("create time"));
        RuleFor(x => x.UpdatedAt)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategoryIssueComment>.InvalidVariableError("update time"));

    }
}


public class PostIssueCommentModelValidator : AbstractValidator<PostIssueCommentModel>
{
    public PostIssueCommentModelValidator()
    {
        RuleFor(x => x.CommentOwnerId)
            .NotNull()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<PostIssueComment>.InvalidVariableError("writer id"));

        RuleFor(x => x.CommentText)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostIssueComment>.InvalidVariableError("text"));

        RuleFor(x => x.IsReply)
            .NotNull()
            .WithState(_ => GenericErrors<PostIssueComment>.InvalidVariableError("is-reply"));

        RuleFor(x => x.PostIssueId)
          .NotNull()
          .GreaterThan(0)
          .WithState(_ => GenericErrors<PostIssueComment>.InvalidVariableError("post category id"));

        RuleFor(x => x.ReplyToCommentId)
          .NotNull()
          .When(x => x.IsReply == true)
          .GreaterThan(0)
          .WithState(_ => GenericErrors<PostIssueComment>.InvalidVariableError("reply to comment id"));

        RuleFor(x => x.CreatedAt)
            .NotNull()
            .WithState(_ => GenericErrors<PostIssueComment>.InvalidVariableError("create time"));
        RuleFor(x => x.UpdatedAt)
            .NotNull()
            .WithState(_ => GenericErrors<PostIssueComment>.InvalidVariableError("update time"));

    }
}

#endregion

public class PostCommentModelValidator : AbstractValidator<PostCommentModel>
{
    public PostCommentModelValidator()
    {
        RuleFor(x => x.CommentOwnerId)
            .NotNull()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("comment writer id"));

        RuleFor(x => x.CommentText)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("comment text"));

        RuleFor(x => x.IsReply)
            .NotNull()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("is-reply"));

        RuleFor(x => x.PostId)
          .NotNull()
          .GreaterThan(0)
          .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("post id"));

        RuleFor(x => x.ReplyToCommentId)
          .NotNull()
          .When(x => x.IsReply == true)
          .GreaterThan(0)
          .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("reply to comment id"));

        RuleFor(x => x.CreatedAt)
            .NotNull()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("create time"));
        RuleFor(x => x.UpdatedAt)
            .NotNull()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("update time"));

    }
}
