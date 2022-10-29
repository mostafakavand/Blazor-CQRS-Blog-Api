using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Blog.Queries;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Blog.Validators.QueryValidators;


#region post issue

public class GetPostIssueFilterQueryModelValidator : AbstractValidator<GetPostIssueByFilterQuery>
{
    public GetPostIssueFilterQueryModelValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("filter"));
    }
}

public class GetPostIssueByIdQueryModelValidator : AbstractValidator<GetPostIssueByIdQuery>
{
    public GetPostIssueByIdQueryModelValidator()
    {
        RuleFor(x => x.PostIssueId)
            .NotNull()
            .WithState(_ => GenericErrors<PostIssue>.InvalidVariableError("id"));
    }
}
#endregion

#region post Category Issue

public class GetPostCategoryIssueFilterQueryModelValidator : AbstractValidator<GetPostCategoryIssueByFilterQuery>
{
    public GetPostCategoryIssueFilterQueryModelValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategoryIssue>.InvalidVariableError("filter"));
    }
}

public class GetPostCategoryIssueByIdQueryModelValidator : AbstractValidator<GetPostCategoryIssueByIdQuery>
{
    public GetPostCategoryIssueByIdQueryModelValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategoryIssue>.InvalidVariableError("id"));
    }
}
#endregion