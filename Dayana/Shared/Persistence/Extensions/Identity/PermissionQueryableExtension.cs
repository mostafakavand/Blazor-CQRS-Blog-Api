
using Dayana.Shared.Domains.Identity.Permissions;
using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.Extensions.Identity;

public static class PermissionQueryableExtension
{
    public static IQueryable<Permission> ApplyFilter(this IQueryable<Permission> query, DefaultPaginationFilter filter)
    {
        // Filter by Value
        if (!string.IsNullOrEmpty(filter.StringValue))
            query = query.Where(x => x.Value.ToLower().Contains(filter.StringValue.ToLower().Trim()));

        // Filter by Name
        if (!string.IsNullOrEmpty(filter.Name))
            query = query.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower().Trim()));

        // Filter by Title
        if (!string.IsNullOrEmpty(filter.Title))
            query = query.Where(x => x.Title.ToLower().Contains(filter.Title.ToLower().Trim()));

        // Filter By RoleId
        if (filter.Id.HasValue)
            query = query.Where(x => x.Roles.Any(x => x.RoleId == filter.Id.Value));


        return query;
    }

    public static IQueryable<Permission> ApplySort(this IQueryable<Permission> query)
    {
        return query.OrderByDescending(x => x.Id);
    }
}