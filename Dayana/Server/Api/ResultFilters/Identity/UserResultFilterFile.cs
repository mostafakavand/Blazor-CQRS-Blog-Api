using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Domains.Identity.Claims;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Identity.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dayana.Server.Api.ResultFilters.Identity;

public class CreateUserPermissionResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is Claim value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.Value
            };

        await next();
    }
}

public class CreateUserResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is User value)
            result.Value = new
            {
                Eid = value.Id,
                value.Username
            };

        await next();
    }
}

public class DeleteUserPermissionResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is Claim value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.Value
            };

        await next();
    }
}


public class GetUserByFilterResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PaginatedList<UserModel> value)
            result.Value = new
            {
                value.Page,
                value.PageSize,
                value.TotalCount,
                Data = value.Data.Select(x => new
                {
                    Eid = x.Id.EncodeInt(),
                    x.Username,
                    x.IsEmailConfirmed,
                    x.IsMobileConfirmed,
                    x.IsLockedOut,
                    x.Mobile,


                    RoleTitles = x.UserRoles.Select(x => x.Role.Title),

                    x.Email,
                    State = nameof(x.State),
                    x.CreatedAt,
                    x.UpdatedAt
                })
            };

        await next();
    }
}


public class GetUserByIdResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is UserModel value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.Username,
                value.IsEmailConfirmed,
                value.IsMobileConfirmed,
                value.IsLockedOut,
                value.Mobile,
                RoleTitles = value.UserRoles.Select(x => x.Role.Title),
                value.Email,
                State = nameof(value.State),
                value.CreatedAt,
                value.UpdatedAt
            };

        await next();
    }
}


public class UpdateUserResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is User value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.Username,
                value.UpdatedAt
            };

        await next();
    }
}


public class UpdateUserRolesResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is UserRole value)
            result.Value = new
            {
                RoleId = value.RoleId.EncodeInt(),
                UserId = value.UserId.EncodeInt()
            };

        await next();
    }
}