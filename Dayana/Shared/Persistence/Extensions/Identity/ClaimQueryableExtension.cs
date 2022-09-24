using Dayana.Shared.Domains.Identity.Claims;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;

namespace Dayana.Shared.Persistence.Extensions.Identity;

public static class ClaimQueryableExtension
{
    public static IQueryable<Claim> ApplyFilter(this IQueryable<Claim> query, DefaultPaginationFilter filter)
    {
        // Filter By RoleId
        if (filter.Id.HasValue)
            query = query.Where(x => x.UserId == filter.Id.Value);

        // Filter By Value
        if (!string.IsNullOrEmpty(filter.StringValue))
            query = query.Where(x => x.Value.ToLower().Contains(filter.StringValue.ToLower().Trim()));

        return query;
    }

    public static IQueryable<Claim> ApplySort(this IQueryable<Claim> query, SortByEnum? sortBy)
    {
        return sortBy switch
        {
            SortByEnum.CreationDate => query.OrderBy(x => x.CreatedAt),
            SortByEnum.CreationDateDescending => query.OrderByDescending(x => x.CreatedAt),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}