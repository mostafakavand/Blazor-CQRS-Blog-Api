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