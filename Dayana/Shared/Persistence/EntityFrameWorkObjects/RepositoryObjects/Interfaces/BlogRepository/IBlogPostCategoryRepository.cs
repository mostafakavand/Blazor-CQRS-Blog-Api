using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Infrastructure.Pagination;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;
public interface IBlogPostCategoryRepository : IRepository<PostCategory>
{
    Task<PostCategory> GetPostCategoryByIdAsync(int id);
    Task<PostCategory> GetPostCategoryByPostnameAsync(string postCategoryname);
    Task<List<PostCategory>> GetPostCategoriesByFilterAsync(DefaultPaginationFilter filter);
}