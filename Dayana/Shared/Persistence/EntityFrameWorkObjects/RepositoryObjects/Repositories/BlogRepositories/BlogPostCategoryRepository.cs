using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Identity.Users;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.IdentityRepositories;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Repositories;
using Dayana.Shared.Persistence.Extensions.Identity;
using Dayana.Shared.Persistence.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;

public class BlogPostCategoryRepository : Repository<PostCategory>, IBlogPostCategoryRepository
{
    private readonly IQueryable<PostCategory> _queryable;


    public BlogPostCategoryRepository(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<PostCategory>();
    }

    public Task<List<PostCategory>> GetPostCategoriesByFilterAsync(DefaultPaginationFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task<List<PostCategory>> GetPostCategoriesByIdsAsync(IEnumerable<int> ids)
    {
        throw new NotImplementedException();
    }

    public async Task<PostCategory> GetPostCategoryByIdAsync(int id)
    {
        var data = await _queryable
            .Include(x => x.PostCategoryIssues)
            .SingleOrDefaultAsync(x => x.Id == id);

        if (data == null)
            throw new NullReferenceException((GenericErrors<PostCategory>.NotFoundError("id")).ToString());

        return data;
    }

    public async Task<PostCategory> GetPostCategoryByPostnameAsync(string postCategoryname)
    {
        var data = await _queryable
          .Include(x => x.PostCategoryIssues)
          .SingleOrDefaultAsync(x => x.CategoryTitle.ToLower() == postCategoryname.ToLower());

        if (data == null)
            throw new NullReferenceException((GenericErrors<PostCategory>.NotFoundError("name")).ToString());

        return data;
    }
}