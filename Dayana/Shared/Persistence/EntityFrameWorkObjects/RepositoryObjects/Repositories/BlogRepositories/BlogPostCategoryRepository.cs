using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;
using Dayana.Shared.Persistence.Extensions.Blog;
using Microsoft.EntityFrameworkCore;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Repositories.BlogRepositories;

public class BlogPostCategoryRepository : Repository<PostCategory>, IBlogPostCategoryRepository
{
    private readonly IQueryable<PostCategory> _queryable;


    public BlogPostCategoryRepository(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<PostCategory>();
    }

    public async Task<List<PostCategory>> GetPostCategoriesByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable;

        query = query.AsNoTracking();

        query = query.ApplyFilter(filter);
        query = query.ApplySort(filter.SortBy);

        return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
    }

    public async Task<PostCategory> GetPostCategoryByIdAsync(int id)
    {
        var data = await _queryable
            .Include(x => x.PostCategoryIssues)
            .SingleOrDefaultAsync(x => x.Id == id);

        if (data == null)
            throw new NullReferenceException(GenericErrors<PostCategory>.NotFoundError("id").ToString());

        return data;
    }

    public async Task<PostCategory> GetPostCategoryByPostnameAsync(string postCategoryname)
    {
        var data = await _queryable
          .Include(x => x.PostCategoryIssues)
          .SingleOrDefaultAsync(x => x.CategoryTitle.ToLower() == postCategoryname.ToLower());

        if (data == null)
            throw new NullReferenceException(GenericErrors<PostCategory>.NotFoundError("name").ToString());

        return data;
    }
}