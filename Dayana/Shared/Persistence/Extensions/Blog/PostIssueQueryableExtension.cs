using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;
namespace Dayana.Shared.Persistence.Extensions.Blog;

public static class PostIssueQueryableExtension
{
    public static IQueryable<PostIssue> ApplyFilter(this IQueryable<PostIssue> query, DefaultPaginationFilter filter)
    {
        // Filter By id
        if (filter.Id.HasValue)
            query = query.Where(x => x.Id == filter.Id.Value);

        // Filter By Value
        if (!string.IsNullOrEmpty(filter.StringValue))
            query = query.Where(x => x.IssueTitle.ToLower().Contains(filter.StringValue.ToLower().Trim()));

        return query;
    }

    public static IQueryable<PostIssue> ApplySort(this IQueryable<PostIssue> query, SortByEnum? sortBy)
    {
        return sortBy switch
        {
            SortByEnum.CreationDate => query.OrderBy(x => x.CreatedAt),
            SortByEnum.CreationDateDescending => query.OrderByDescending(x => x.CreatedAt),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}