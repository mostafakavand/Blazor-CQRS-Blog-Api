using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;

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
