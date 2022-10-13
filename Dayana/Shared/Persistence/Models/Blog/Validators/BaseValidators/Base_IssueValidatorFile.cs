using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Blog.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Validators.BaseValidators;

public class PostIssueModelValidator : AbstractValidator<PostIssueModel>
{
    public PostIssueModelValidator()
    {
        RuleFor(x => x.PostId)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("post id"));

        RuleFor(x => x.IssueTitle)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("title"));

        RuleFor(x => x.IssueWriterId)
            .NotNull()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("writer id"));

        RuleFor(x => x.IssueDescription)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("description"));
    }
}


public class PostCategoryIssueModelValidator : AbstractValidator<PostCategoryIssueModel>
{
    public PostCategoryIssueModelValidator()
    {
        RuleFor(x => x.PostCategoryId)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategoryIssue>.InvalidVariableError("category id"));

        RuleFor(x => x.IssueTitle)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategoryIssue>.InvalidVariableError("title"));

        RuleFor(x => x.IssueWriterId)
            .NotNull()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<PostCategoryIssue>.InvalidVariableError("writer id"));

        RuleFor(x => x.IssueDescription)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostCategoryIssue>.InvalidVariableError("description"));
    }
}

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