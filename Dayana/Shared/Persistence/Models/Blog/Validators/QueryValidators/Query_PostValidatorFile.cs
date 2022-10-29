using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Blog.Queries;
using FluentValidation;

#region Post

public class GetPostByFilterQueryModelValidator : AbstractValidator<GetPostByFilterQuery>
{
    public GetPostByFilterQueryModelValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("filter"));
    }
}

public class GetPostByIdQueryModelValidator : AbstractValidator<GetPostByIdQuery>
{
    public GetPostByIdQueryModelValidator()
    {
        RuleFor(x => x.PostId)
            .NotNull()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("id"));
    }
}

#endregion


#region Post Category

public class GetPostCategoryByFilterQueryModelValidator : AbstractValidator<GetPostCategoryByFilterQuery>
{
    public GetPostCategoryByFilterQueryModelValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .WithState(_ => GenericErrors<PostCategory>.InvalidVariableError("filter"));
    }
}

public class GetPostCategoryByIdQueryModelValidator : AbstractValidator<GetPostCategoryByIdQuery>
{
    public GetPostCategoryByIdQueryModelValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithState(_ => GenericErrors<Post>.InvalidVariableError("id"));
    }
}

#endregion