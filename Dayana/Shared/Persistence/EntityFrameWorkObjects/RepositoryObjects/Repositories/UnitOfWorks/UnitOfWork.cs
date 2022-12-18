using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;


namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Repositories.UnitOfWorks;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    IBlogPostCategoryRepository BlogPostCategories { get; }

    IBlogPostRepository BlogPosts { get; }

    IPostCategoryIssueCommentRepository PostCategoryIssueComments { get; }

    IPostCategoryIssueRepository PostCategoryIssue { get; }

    IPostCommentRepository PostComments { get; }

    IPostIssueCommentRepository PostIssueComments { get; }

    IPostIssueRepository PostIssues { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        BlogPostCategories = new BlogPostCategoryRepository(_context);
        BlogPosts = new BlogPostRepository(_context);
        PostCategoryIssueComments = new PostCategoryIssueCommentRepository(_context);
        PostCategoryIssue= new PostCategoryIssueRepository(_context);
        PostComments = new PostCommentRepository(_context);
        PostIssueComments = new PostIssueCommentRepository(_context);
        PostIssues = new PostIssueRepository(_context);
    }

    public async Task<bool> CommitAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}