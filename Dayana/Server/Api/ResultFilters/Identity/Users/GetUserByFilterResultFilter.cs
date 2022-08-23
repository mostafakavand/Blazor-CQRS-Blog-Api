using Dayana.Shared.Basic.ConfigAndConstants.Constants.ConstMethods;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Identity.Base.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dayana.Server.Api.ResultFilters.Identity.Users;

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