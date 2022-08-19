using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Persistence.Models.Filters.Roles;

namespace Dayana.Shared.Persistence.Extensions.Identity;

public static class RoleQueryableExtension
{
    public static IQueryable<Role> ApplyFilter(this IQueryable<Role> query, RoleFilter filter)
    {
        // Filter by permission ids
        if (filter.PermissionIds != null)
            query = query.Where(x => x.RolePermission.Any(x => filter.PermissionIds.Contains(x.PermissionId)));

        // Filter by title
        if (!string.IsNullOrEmpty(filter.Title))
            query = query.Where(x => x.Title.ToLower().Contains(filter.Title.ToLower().Trim()));

        return query;
    }

    public static IQueryable<Role> ApplySort(this IQueryable<Role> query, RoleSortBy? sortBy)
    {
        return sortBy switch
        {
            RoleSortBy.CreationDate => query.OrderBy(x => x.CreatedAt),
            RoleSortBy.CreationDateDescending => query.OrderByDescending(x => x.CreatedAt),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}