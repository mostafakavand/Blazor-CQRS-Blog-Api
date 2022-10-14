using Dayana.Shared.Domains.Blog.Comments;
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

#region Post Issue 


public class CreatePostIssueCommandValidator : AbstractValidator<CreatePostIssueCommand>
{
    public CreatePostIssueCommandValidator()
    {
        RuleFor(x => x.IssueTitle)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("title"));

        RuleFor(x => x.IssueDescription)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("description"));

        RuleFor(x => x.PostId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("post id"));
    }
}



public class DeletePostIssueCommandValidator : AbstractValidator<DeletePostIssueCommand>
{
    public DeletePostIssueCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("id"));

        RuleFor(x => x.PostId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("post id"));
    }
}



public class UpdatePostIssueCommandValidator : AbstractValidator<UpdatePostIssueCommand>
{
    public UpdatePostIssueCommandValidator()
    {
        RuleFor(x => x.IssueTitle)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("title"));

        RuleFor(x => x.IssueDescription)
            .NotNull()
            .NotNull()
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("description"));

        RuleFor(x => x.PostId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("post id"));
    }
}

#endregion

#region Post Category Issue 


public class CreatePostCategoryIssueCommandValidator : AbstractValidator<CreatePostCategoryIssueCommand>
{
    public CreatePostCategoryIssueCommandValidator()
    {
        RuleFor(x => x.IssueTitle)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("title"));

        RuleFor(x => x.IssueDescription)
            .NotNull()
            .NotNull()
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("description"));

        RuleFor(x => x.PostCategoryId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("post category id"));
    }
}



public class DeletePostCategoryIssueCommandValidator : AbstractValidator<DeletePostCategoryIssueCommand>
{
    public DeletePostCategoryIssueCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("id"));

        RuleFor(x => x.PostCategoryId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("post category id"));
    }
}



public class UpdatePostCategoryIssueCommandValidator : AbstractValidator<UpdatePostCategoryIssueCommand>
{
    public UpdatePostCategoryIssueCommandValidator()
    {
        RuleFor(x => x.IssueTitle)
            .NotNull()
            .NotEmpty()
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("title"));

        RuleFor(x => x.IssueDescription)
            .NotNull()
            .NotNull()
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("description"));

        RuleFor(x => x.PostCategoryId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0)
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("post id"));
    }
}

#endregion
