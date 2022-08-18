namespace Dayana.Shared.Persistence.Models.Base.Blog;

public class PostModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Summery { get; set; }
    public string TextContent { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CreatorId { get; set; }
    public int UpdaterId { get; set; }

    public PostCategoryModel WeblogPostCategoryModel { get; set; }
}