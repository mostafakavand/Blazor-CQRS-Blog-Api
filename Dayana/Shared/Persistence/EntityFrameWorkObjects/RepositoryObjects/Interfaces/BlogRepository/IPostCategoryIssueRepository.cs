using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;

public interface IPostCategoryIssueRepository : IRepository<PostCategoryIssue>
{
    Task<PostCategoryIssue> GetPostCategoryIssueByIdAsync(int id);
    Task<PostCategoryIssue> GetPostCategoryIssueByPostCategoryIssuenameAsync(string PostCategoryIssuename);
    Task<List<PostCategoryIssue>> GetPostCategoryIssuesByIdsAsync(IEnumerable<int> ids);
    Task<List<PostCategoryIssue>> GetPostCategoryIssuesByFilterAsync(DefaultPaginationFilter filter);
}