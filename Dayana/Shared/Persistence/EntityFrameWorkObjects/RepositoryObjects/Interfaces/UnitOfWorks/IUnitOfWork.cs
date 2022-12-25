using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.IdentityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;
public interface IUnitOfWork : IDisposable
{
    IBlogPostCategoryRepository BlogPostCategories { get; }
    IBlogPostRepository BlogPosts { get; }
    IPostCategoryIssueCommentRepository PostCategoryIssueComments { get; }
    IPostCategoryIssueRepository PostCategoryIssues { get; }
    IPostCommentRepository PostComments { get; }
    IPostIssueCommentRepository PostIssueComments { get; }
    IPostIssueRepository PostIssues { get; }

    Task<bool> CommitAsync();
 
}
