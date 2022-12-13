using Dayana.Shared.Basic.MethodsAndObjects.BaseServices.Specifications;
using Dayana.Shared.Domains.Identity.Roles;
using System.Linq.Expressions;

namespace Dayana.Server.Application.Specifications.Identity;

public class DuplicateRoleSpecificationFile : Specification<Role>
{
    private readonly string _title;

    public DuplicateRoleSpecificationFile(string title)
    {
        _title = title;
    }

    public override Expression<Func<Role, bool>> ToExpression()
    {
        return role => role.Title.ToLower() == _title.ToLower();
    }
}