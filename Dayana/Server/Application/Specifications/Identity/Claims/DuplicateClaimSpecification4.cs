using Dayana.Shared.Basic.MethodsAndObjects.BaseServices.Specifications;
using Dayana.Shared.Domains.Identity.Claims;
using System.Linq.Expressions;

namespace Dayana.Server.Application.Specifications.Identity.Claims;

public class DuplicateClaimSpecification : Specification<Claim>
{
    private readonly int _userId;
    private readonly int _permissionId;

    public DuplicateClaimSpecification(int userId, int permissionId)
    {
        _userId = userId;
        _permissionId = permissionId;
    }

    public override Expression<Func<Claim, bool>> ToExpression()
    {
        return claim => claim.Value == _permissionId.ToString() && claim.UserId == _userId;
    }
}