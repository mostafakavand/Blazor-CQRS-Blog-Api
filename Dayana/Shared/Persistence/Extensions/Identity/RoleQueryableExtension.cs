using Dayana.Shared.Domains.Identity.Roles;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;

namespace Dayana.Shared.Persistence.Extensions.Identity;

public static class RoleQueryableExtension
{
    public static IQueryable<Role> ApplyFilter(this IQueryable<Role> query, DefaultPaginationFilter filter)
    {
        // Filter by permission ids
        if (filter.IntValueList != null)
            query = query.Where(x => x.RolePermission.Any(x => filter.IntValueList.Contains(x.PermissionId)));

        // Filter by title
        if (!string.IsNullOrEmpty(filter.Title))
            query = query.Where(x => x.Title.ToLower().Contains(filter.Title.ToLower().Trim()));

        return query;
    }

    public static IQueryable<Role> ApplySort(this IQueryable<Role> query, SortByEnum? sortBy)
    {
        return sortBy switch
        {
            SortByEnum.CreationDate => query.OrderBy(x => x.CreatedAt),
            SortByEnum.CreationDateDescending => query.OrderByDescending(x => x.CreatedAt),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}