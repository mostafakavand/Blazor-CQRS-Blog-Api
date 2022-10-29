using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Blog.Base;
using FluentValidation;

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