using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Blog.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Validators.QueryValidators;

#region post and post category issue comment

public class GetPostIssueCommentFilterQueryModelValidator : AbstractValidator<GetPostIssueCommentFilterQuery>
{
    public GetPostIssueCommentFilterQueryModelValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .WithState(_ => GenericErrors<PostIssueComment>.InvalidVariableError("filter"));
    }
}

public class GetPostIssueCommentByIdQueryModelValidator : AbstractValidator<GetPostIssueCommentByIdQuery>
{
    public GetPostIssueCommentByIdQueryModelValidator()
    {
        RuleFor(x => x.PostIssueId)
            .NotNull()
            .WithState(_ => GenericErrors<PostIssueComment>.InvalidVariableError("id"));
    }
}


public class GetPostCategoryIssueCommentFilterQueryModelValidator : AbstractValidator<GetPostCategoryIssueCommentFilterQuery>
{
    public GetPostCategoryIssueCommentFilterQueryModelValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategoryIssueComment>.InvalidVariableError("filter"));
    }
}

public class GetPostCategoryIssueCommentByIdQueryModelValidator : AbstractValidator<GetPostCategoryIssueCommentByIdQuery>
{
    public GetPostCategoryIssueCommentByIdQueryModelValidator()
    {
        RuleFor(x => x.PostCategoryIssueId)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategoryIssueComment>.InvalidVariableError("id"));
    }
}

#endregion

#region post issue

public class GetPostIssueFilterQueryModelValidator : AbstractValidator<GetPostIssueFilterQuery>
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