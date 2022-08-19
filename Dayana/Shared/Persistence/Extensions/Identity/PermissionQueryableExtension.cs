
using Dayana.Shared.Domains.Identity.Permissions;
using Dayana.Shared.Persistence.Models.Identity.Filters.Permissions;

namespace Dayana.Shared.Persistence.Extensions.Identity;

public static class PermissionQueryableExtension
{
    public static IQueryable<Permission> ApplyFilter(this IQueryable<Permission> query, PermissionFilter filter)
    {
        // Filter by Value
        if (!string.IsNullOrEmpty(filter.Value))
            query = query.Where(x => x.Value.ToLower().Contains(filter.Value.ToLower().Trim()));

        // Filter by Name
        if (!string.IsNullOrEmpty(filter.Name))
            query = query.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower().Trim()));

        // Filter by Title
        if (!string.IsNullOrEmpty(filter.Title))
            query = query.Where(x => x.Title.ToLower().Contains(filter.Title.ToLower().Trim()));

        // Filter By RoleId
        if (filter.RoleId.HasValue)
            query = query.Where(x => x.Roles.Any(x => x.RoleId == filter.RoleId.Value));


        return query;
    }

    public static IQueryable<Permission> ApplySort(this IQueryable<Permission> query)
    {
        return query.OrderByDescending(x => x.Id);
    }
}