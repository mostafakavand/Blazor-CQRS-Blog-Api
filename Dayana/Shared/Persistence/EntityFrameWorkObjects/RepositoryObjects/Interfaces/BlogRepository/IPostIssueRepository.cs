using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;

public interface IPostIssueRepository : IRepository<PostIssue>
{
    Task<PostIssue> GetPostIssueByIdAsync(int id);
    Task<PostIssue> GetPostIssueByPostnameAsync(string postCategoryIssueCommentname);
    Task<List<PostIssue>> GetPostCategoriesByIdsAsync(IEnumerable<int> ids);
    Task<List<PostIssue>> GetPostCategoriesByFilterAsync(DefaultPaginationFilter filter);
}