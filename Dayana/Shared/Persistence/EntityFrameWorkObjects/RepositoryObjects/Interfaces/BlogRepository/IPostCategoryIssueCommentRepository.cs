using Dayana.Shared.Domains.Blog.BlogPosts;
using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;

public interface IPostCategoryIssueCommentRepository : IRepository<PostCategoryIssueComment>
{
    Task<PostCategoryIssueComment> GetPostCategoryIssueCommentByIdAsync(int id);
    Task<PostCategoryIssueComment> GetPostCategoryIssueCommentByPostnameAsync(string postCategoryIssueCommentname);
    Task<List<PostCategoryIssueComment>> GetPostCategoriesByIdsAsync(IEnumerable<int> ids);
    Task<List<PostCategoryIssueComment>> GetPostCategoriesByFilterAsync(DefaultPaginationFilter filter);
}