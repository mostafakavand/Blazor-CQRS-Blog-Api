using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;

public interface IBlogPostRepository : IRepository<Post>
{
    Task<Post> GetPostByIdAsync(int id);
    Task<Post> GetPostByPostnameAsync(string Postname);
    Task<List<Post>> GetPostsByFilterAsync(DefaultPaginationFilter filter);
}