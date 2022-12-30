using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;
using Dayana.Shared.Persistence.Extensions.Blog;
using Microsoft.EntityFrameworkCore;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Repositories.BlogRepositories;


public class BlogPostRepository : Repository<Post>, IBlogPostRepository
{
    private readonly IQueryable<Post> _queryable;


    public BlogPostRepository(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<Post>();
    }

    public async Task<List<Post>> GetPostsByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable;

        query = query.AsNoTracking();

        query = query.ApplyFilter(filter);
        query = query.ApplySort(filter.SortBy);

        return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
    }

    public async Task<Post> GetPostByIdAsync(int id)
    {
        var data = await _queryable
            .Include(x => x.PostIssues)
            .SingleOrDefaultAsync(x => x.Id == id);

        if (data == null)
            throw new NullReferenceException(GenericErrors<Post>.NotFoundError("id").ToString());

        return data;
    }

    public async Task<Post> GetPostByPostnameAsync(string postCategoryname)
    {
        var data = await _queryable
          .Include(x => x.PostIssues)
          .SingleOrDefaultAsync(x => x.PostTitle.ToLower() == postCategoryname.ToLower());

        if (data == null)
            throw new NullReferenceException(GenericErrors<Post>.NotFoundError("name").ToString());

        return data;
    }
}
