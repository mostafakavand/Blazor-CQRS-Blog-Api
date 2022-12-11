using Dayana.Shared.Basic.MethodsAndObjects.BaseServices.Specifications;
using Dayana.Shared.Domains.Blog.BlogPosts;
using System.Linq.Expressions;

namespace Dayana.Server.Application.Specifications.Blog;

#region post 
public class DuplicatePostSpecification : Specification<Post>
{
    private readonly string _Title;

    public DuplicatePostSpecification(string title)
    {
        _Title = title;
    }

    public override Expression<Func<Post, bool>> ToExpression()
    {
        return user => user.PostTitle.ToLower() == _Title.ToLower();
    }
}
#endregion

#region postCategory
public class DuplicatePostCategorySpecification : Specification<PostCategory>
{
    private readonly string _Title;

    public DuplicatePostCategorySpecification(string title)
    {
        _Title = title;
    }

    public override Expression<Func<PostCategory, bool>> ToExpression()
    {
        return user => user.CategoryTitle.ToLower() == _Title.ToLower();
    }
}
#endregion