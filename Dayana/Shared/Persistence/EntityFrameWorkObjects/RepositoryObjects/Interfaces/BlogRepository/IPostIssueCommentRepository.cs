using Dayana.Shared.Domains.Blog.Comments;
using Dayana.Shared.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;

public interface IPostIssueCommentRepository : IRepository<PostIssueComment>
{
    Task<PostIssueComment> GetPostIssueCommentByIdAsync(int id);
    Task<PostIssueComment> GetPostIssueCommentByPostnameAsync(string postCategoryIssueCommentname);
    Task<List<PostIssueComment>> GetPostCategoriesByIdsAsync(IEnumerable<int> ids);
    Task<List<PostIssueComment>> GetPostCategoriesByFilterAsync(DefaultPaginationFilter filter);
}