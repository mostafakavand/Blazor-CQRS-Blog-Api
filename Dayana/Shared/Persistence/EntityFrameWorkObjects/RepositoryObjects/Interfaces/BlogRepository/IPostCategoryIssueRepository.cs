using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;

public interface IPostCategoryIssueRepository : IRepository<PostCategoryIssue>
{
    Task<PostCategoryIssue> GetPostCategoryIssueByIdAsync(int id);
    Task<PostCategoryIssue> GetPostCategoryIssueByTitleAsync(string PostCategoryIssuename);
    Task<List<PostCategoryIssue>> GetPostCategoryIssuesByFilterAsync(DefaultPaginationFilter filter);
}