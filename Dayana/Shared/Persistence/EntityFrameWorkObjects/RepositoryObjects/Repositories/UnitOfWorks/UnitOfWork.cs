using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.BlogRepository;
using Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.UnitOfWorks;


namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Repositories.UnitOfWorks;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
   
    public IBlogPostCategoryRepository BlogPostCategories { get;}

    public IBlogPostRepository BlogPosts { get;}

    public IPostCategoryIssueCommentRepository PostCategoryIssueComments { get;}

    public IPostCategoryIssueRepository PostCategoryIssue { get;}

    public IPostCommentRepository PostComments { get;}

    public IPostIssueCommentRepository PostIssueComments { get;}

    public IPostIssueRepository PostIssues { get;}

    public async Task<bool> CommitAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        BlogPostCategories = new BlogPostCategoryRepository(_context);
        BlogPosts = new BlogPostRepository(_context);
        PostCategoryIssueComments = new PostCategoryIssueCommentRepository(_context);
        PostCategoryIssue = new PostCategoryIssueRepository(_context);
        PostComments = new PostCommentRepository(_context);
        PostIssueComments = new PostIssueCommentRepository(_context);
        PostIssues = new PostIssueRepository(_context);
    }

}