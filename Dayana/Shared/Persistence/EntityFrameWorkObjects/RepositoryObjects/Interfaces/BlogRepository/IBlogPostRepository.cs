using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;

public interface IBlogPostRepository : IRepository<Post>
{
    Task<Post> GetPostByIdAsync(int id);
    Task<Post> GetPostByPostnameAsync(string Postname);
    Task<List<Post>> GetPostsByIdsAsync(IEnumerable<int> ids);
    Task<List<Post>> GetPostsByFilterAsync(DefaultPaginationFilter filter);
}