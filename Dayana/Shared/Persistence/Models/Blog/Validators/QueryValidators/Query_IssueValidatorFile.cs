using Dayana.Shared.Domains.Blog.BlogPosts;
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

public class GetPostByFilterQueryModelValidator : AbstractValidator<GetPostByFilterQuery>
{
    public GetPostByFilterQueryModelValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("filter"));
    }
}

#endregion