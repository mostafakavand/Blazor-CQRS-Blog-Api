﻿using System.Linq.Expressions;

namespace Dayana.Server.Application.Specifications.Identity.Claims;

public class DuplicateClaimSpecification : Specification<Claim>
{
    private readonly int _userId;
    private readonly int _permissionId;
    private readonly ClaimType _claimType;

    public DuplicateClaimSpecification(int userId, int permissionId, ClaimType claimType)
    {
        _userId = userId;
        _permissionId = permissionId;
        _claimType = claimType;
    }

    public override Expression<Func<Claim, bool>> ToExpression()
    {
        return claim => claim.Type == _claimType && claim.Value == _permissionId.ToString() && claim.UserId == _userId;
    }
}