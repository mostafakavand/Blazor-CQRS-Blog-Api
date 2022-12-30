using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;
using Dayana.Shared.Persistence.Extensions.Blog;
using Microsoft.EntityFrameworkCore;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Repositories.BlogRepositories;

public class PostCategoryIssueRepository : Repository<PostCategoryIssue>, IPostCategoryIssueRepository
{
    private readonly IQueryable<PostCategoryIssue> _queryable;


    public PostCategoryIssueRepository(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<PostCategoryIssue>();
    }

    public async Task<List<PostCategoryIssue>> GetPostCategoryIssuesByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable;

        query = query.AsNoTracking();

        query = query.ApplyFilter(filter);
        query = query.ApplySort(filter.SortBy);

        return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
    }

    public async Task<PostCategoryIssue> GetPostCategoryIssueByIdAsync(int id)
    {
        var data = await _queryable
            .SingleOrDefaultAsync(x => x.Id == id);

        if (data == null)
            throw new NullReferenceException(GenericErrors<PostCategoryIssue>.NotFoundError("id").ToString());

        return data;
    }

    public async Task<PostCategoryIssue> GetPostCategoryIssueByTitleAsync(string postCategoryname)
    {
        var data = await _queryable
          .SingleOrDefaultAsync(x => x.IssueTitle.ToLower() == postCategoryname.ToLower());

        if (data == null)
            throw new NullReferenceException(GenericErrors<PostCategoryIssue>.NotFoundError("name").ToString());

        return data;
    }
}