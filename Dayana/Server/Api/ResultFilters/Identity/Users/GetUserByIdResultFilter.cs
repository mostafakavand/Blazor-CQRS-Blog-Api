using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Persistence.Models.Identity.Base.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dayana.Server.Api.ResultFilters.Identity.Users;

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