using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Validators.CommandValidators;

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