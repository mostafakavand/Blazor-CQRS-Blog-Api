﻿using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Repositories;
using Dayana.Shared.Persistence.Extensions.Blog;
using Microsoft.EntityFrameworkCore;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;


public class PostIssueRepository : Repository<PostIssue>, IPostIssueRepository
{
    private readonly IQueryable<PostIssue> _queryable;


    public PostIssueRepository(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<PostIssue>();
    }

    public async Task<List<PostIssue>> GetPostIssuesByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable;

        query = query.AsNoTracking();

        query = query.ApplyFilter(filter);
        query = query.ApplySort((filter.SortBy));

        return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
    }

    public async Task<PostIssue> GetPostIssueByIdAsync(int id)
    {
        var data = await _queryable.SingleOrDefaultAsync(x => x.Id == id);

        if (data == null)
            throw new NullReferenceException((GenericErrors<PostIssue>.NotFoundError("id")).ToString());

        return data;
    }
}


