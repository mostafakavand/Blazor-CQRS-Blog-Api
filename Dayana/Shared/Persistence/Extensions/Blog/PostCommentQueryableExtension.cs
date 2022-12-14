using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Enums;

namespace Dayana.Shared.Persistence.Extensions.Blog;
public static class PostCommentQueryableExtension
{
    public static IQueryable<PostComment> ApplyFilter(this IQueryable<PostComment> query, DefaultPaginationFilter filter)
    {
        // Filter By id
        if (filter.Id.HasValue)
            query = query.Where(x => x.Id == filter.Id.Value);

        // Filter By Value
        if (!string.IsNullOrEmpty(filter.StringValue))
            query = query.Where(x => x.CommentText.ToLower().Contains(filter.StringValue.ToLower().Trim()));

        return query;
    }

    public static IQueryable<PostComment> ApplySort(this IQueryable<PostComment> query, SortByEnum? sortBy)
    {
        return sortBy switch
        {
            SortByEnum.CreationDate => query.OrderBy(x => x.CreatedAt),
            SortByEnum.CreationDateDescending => query.OrderByDescending(x => x.CreatedAt),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}