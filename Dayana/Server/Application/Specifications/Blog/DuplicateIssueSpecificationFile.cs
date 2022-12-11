using Dayana.Shared.Basic.MethodsAndObjects.BaseServices.Specifications;
using Dayana.Shared.Domains.Blog.Issues;
using System.Linq.Expressions;

namespace Dayana.Server.Application.Specifications.Blog;

#region post issue
public class DuplicatePostIssueSpecification : Specification<PostIssue>
{
    private readonly string _Title;

    public DuplicatePostIssueSpecification(string title)
    {
        _Title = title;
    }

    public override Expression<Func<PostIssue, bool>> ToExpression()
    {
        return user => user.IssueTitle.ToLower() == _Title.ToLower();
    }
}
#endregion

#region postCategory issue
public class DuplicatePostCategoryIssueSpecification : Specification<PostCategoryIssue>
{
    private readonly string _Title;

    public DuplicatePostCategoryIssueSpecification(string title)
    {
        _Title = title;
    }

    public override Expression<Func<PostCategoryIssue, bool>> ToExpression()
    {
        return user => user.IssueTitle.ToLower() == _Title.ToLower();
    }
}
#endregion