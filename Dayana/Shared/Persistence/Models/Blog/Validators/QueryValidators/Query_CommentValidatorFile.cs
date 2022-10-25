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

public class GetPostCommentFilterQueryModelValidator : AbstractValidator<GetPostCommentFilterQuery>
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

#region post Category comment

public class GetPostCategoryCommentFilterQueryModelValidator : AbstractValidator<GetPostCategoryCommentByFilterQuery>
{
    public GetPostCategoryCommentFilterQueryModelValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("filter"));
    }
}

public class GetPostCategoryCommentByIdQueryModelValidator : AbstractValidator<GetPostCategoryCommentByIdQuery>
{
    public GetPostCategoryCommentByIdQueryModelValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategoryComment>.InvalidVariableError("id"));
    }
}
#endregion