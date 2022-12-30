﻿using Dayana.Shared.Basic.MethodsAndObjects.Extension;
using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Infrastructure.Errors;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;
using Dayana.Shared.Persistence.Extensions.Blog;
using Microsoft.EntityFrameworkCore;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Repositories.BlogRepositories;


public class PostIssueCommentRepository : Repository<PostIssueComment>, IPostIssueCommentRepository
{
    private readonly IQueryable<PostIssueComment> _queryable;


    public PostIssueCommentRepository(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<PostIssueComment>();
    }

    public async Task<List<PostIssueComment>> GetPostIssueCommentsByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable;

        query = query.AsNoTracking();

        query = query.ApplyFilter(filter);
        query = query.ApplySort(filter.SortBy);

        return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
    }

    public async Task<PostIssueComment> GetPostIssueCommentByIdAsync(int id)
    {
        var data = await _queryable.SingleOrDefaultAsync(x => x.Id == id);

        if (data == null)
            throw new NullReferenceException(GenericErrors<PostIssueComment>.NotFoundError("id").ToString());

        return data;
    }
}
