using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;

public interface IPostCategoryIssueRepository : IRepository<PostCategoryIssue>
{
    Task<PostCategoryIssue> GetPostCategoryIssueByIdAsync(int id);
    Task<PostCategoryIssue> GetPostCategoryIssueByPostCategoryIssuenameAsync(string PostCategoryIssuename);
    Task<List<PostCategoryIssue>> GetPostCategoryIssuesByIdsAsync(IEnumerable<int> ids);
    Task<List<PostCategoryIssue>> GetPostCategoryIssuesByFilterAsync(DefaultPaginationFilter filter);
}