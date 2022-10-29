using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Identity.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dayana.Server.Api.ResultFilters.Identity;

public class CreateRoleResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is Role value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.Title,
            };

        await next();
    }
}

public class DeleteRoleResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is Role value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt()
            };

        await next();
    }
}


public class GetRoleByIdResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is RoleModel value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.Title,
                value.CreatedAt,
                value.UpdatedAt,
                Permissions = value.Permissions.Select(x => new
                {
                    Eid = x.Id.EncodeInt(),
                    x.Title,
                    x.Name,
                    x.Value
                })
            };

        await next();
    }
}

public class GetRolesByFilterResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PaginatedList<RoleModel> value)
            result.Value = new
            {
                value.Page,
                value.PageSize,
                value.TotalCount,
                Data = value.Data.Select(x => new
                {
                    Eid = x.Id.EncodeInt(),
                    x.Title,
                    x.CreatedAt,
                    x.UpdatedAt
                })
            };

        await next();
    }
}

public class UpdateRoleResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is Role value)
            result.Value = new
            {
                Eid = value.Id.EncodeInt(),
                value.UpdatedAt
            };

        await next();
    }
}
