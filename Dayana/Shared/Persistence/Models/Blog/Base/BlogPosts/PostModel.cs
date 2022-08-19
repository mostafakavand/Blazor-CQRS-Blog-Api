namespace Dayana.Shared.Persistence.Models.Blog.Base.BlogPosts;

public class PostModel
{
    public int Id { get; set; }
    public string PostTitle { get; set; }
    public string Summery { get; set; }
    public string PostBody { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CreatorId { get; set; }
    public int UpdaterId { get; set; }

    public PostCategoryModel WeblogPostCategoryModel { get; set; }
}