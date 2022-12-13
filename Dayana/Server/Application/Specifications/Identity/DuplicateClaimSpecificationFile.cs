using Dayana.Shared.Basic.MethodsAndObjects.BaseServices.Specifications;
using Dayana.Shared.Domains.Identity.Claims;
using System.Linq.Expressions;

namespace Dayana.Server.Application.Specifications.Identity;

public class DuplicateClaimSpecificationFile : Specification<Claim>
{
    private readonly int _userId;
    private readonly int _permissionId;

    public DuplicateClaimSpecificationFile(int userId, int permissionId)
    {
        _userId = userId;
        _permissionId = permissionId;
    }

    public override Expression<Func<Claim, bool>> ToExpression()
    {
        return claim => claim.Value == _permissionId.ToString() && claim.UserId == _userId;
    }
}