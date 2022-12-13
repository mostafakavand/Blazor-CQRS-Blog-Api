using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;

public interface IPostIssueCommentRepository : IRepository<PostIssueComment>
{
    Task<PostIssueComment> GetPostIssueCommentByIdAsync(int id);
    Task<PostIssueComment> GetPostIssueCommentByPostnameAsync(string postCategoryIssueCommentname);
    Task<List<PostIssueComment>> GetPostCategoriesByIdsAsync(IEnumerable<int> ids);
    Task<List<PostIssueComment>> GetPostCategoriesByFilterAsync(DefaultPaginationFilter filter);
}