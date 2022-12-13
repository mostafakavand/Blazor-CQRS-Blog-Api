using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;

public interface IPostIssueRepository : IRepository<PostIssue>
{
    Task<PostIssue> GetPostIssueByIdAsync(int id);
    Task<PostIssue> GetPostIssueByPostnameAsync(string postCategoryIssueCommentname);
    Task<List<PostIssue>> GetPostCategoriesByIdsAsync(IEnumerable<int> ids);
    Task<List<PostIssue>> GetPostCategoriesByFilterAsync(DefaultPaginationFilter filter);
}