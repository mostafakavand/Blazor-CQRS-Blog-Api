using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Blog.Base;
using Dayana.Shared.Persistence.Models.Blog.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.Models.Blog.Validators.QueryValidators;


#region post comment

public class GetPostCommentFilterQueryModelValidator : AbstractValidator<GetPostCommentByFilterQuery>
{
    public GetPostCommentFilterQueryModelValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("filter"));
    }
}

public class GetPostCommentByIdQueryModelValidator : AbstractValidator<GetPostCommentByIdQuery>
{
    public GetPostCommentByIdQueryModelValidator()
    {
        RuleFor(x => x.PostCommentId)
            .NotNull()
            .WithState(_ => GenericErrors<PostComment>.InvalidVariableError("id"));
    }
}
#endregion

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
