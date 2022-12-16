using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;

public interface IPostCommentRepository : IRepository<PostComment>
{
    Task<PostComment> GetPostCommentByIdAsync(int id);
    Task<List<PostComment>> GetPostCommentsByFilterAsync(DefaultPaginationFilter filter);
}