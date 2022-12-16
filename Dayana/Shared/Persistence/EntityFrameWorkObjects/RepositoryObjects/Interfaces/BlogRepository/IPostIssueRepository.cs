using Dayana.Shared.Domains.Blog.Issues;
using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;

public interface IPostIssueRepository : IRepository<PostIssue>
{
    Task<PostIssue> GetPostIssueByIdAsync(int id);
    Task<List<PostIssue>> GetPostIssuesByFilterAsync(DefaultPaginationFilter filter);
}