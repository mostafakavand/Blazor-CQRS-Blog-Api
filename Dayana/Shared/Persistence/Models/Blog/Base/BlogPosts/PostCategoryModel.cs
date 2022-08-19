namespace Dayana.Shared.Persistence.Models.Blog.Base.BlogPosts;

public class PostCategoryModel
{
    public int Id { get; set; }
    public string CategoryTitle { get; set; }
    public string CategoryIcon { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CreatorId { get; set; }
    public int UpdaterId { get; set; }

    public ICollection<PostModel> WeblogPostModels { get; set; }
}