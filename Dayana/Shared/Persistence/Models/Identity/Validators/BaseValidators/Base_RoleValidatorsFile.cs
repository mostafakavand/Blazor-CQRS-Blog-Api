﻿using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Persistence.Models.Identity.Base;
using FluentValidation;

namespace Dayana.Shared.Persistence.Models.Identity.Validators.BaseValidators;

public class RoleModelValidator : AbstractValidator<RoleModel>
{
    public RoleModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(0)
            .WithState(_ => GenericErrors<RoleModel>.InvalidVariableError("id"));

        RuleFor(x => x.Title)
           .NotEmpty()
           .WithState(_ => GenericErrors<RoleModel>.InvalidVariableError("title"));
    }
}

public class RolePermissionModelValidator : AbstractValidator<RolePermissionModel>
{
    public RolePermissionModelValidator()
    {
        RuleFor(x => x.RoleId)
            .NotEqual(0)
            .WithState(_ => GenericErrors<RolePermissionModel>.InvalidVariableError("role id"));

        RuleFor(x => x.PermissionId)
             .NotEqual(0)
             .WithState(_ => GenericErrors<RolePermissionModel>.InvalidVariableError("premission id"));
    }
}