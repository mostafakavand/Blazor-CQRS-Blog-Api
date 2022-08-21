using Dayana.Shared.Basic.MethodsAndObjects.BaseServices.Specifications;
using Dayana.Shared.Domains.Identity.Users;
using System.Linq.Expressions;

namespace Dayana.Server.Application.Specifications.Identity.Users;

public class DuplicateUserSpecification : Specification<User>
{
    private readonly string _username;

    public DuplicateUserSpecification(string username)
    {
        _username = username;
    }

    public override Expression<Func<User, bool>> ToExpression()
    {
        return user => user.Username.ToLower() == _username.ToLower();
    }
}