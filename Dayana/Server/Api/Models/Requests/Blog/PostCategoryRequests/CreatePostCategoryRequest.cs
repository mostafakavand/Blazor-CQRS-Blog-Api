namespace Dayana.Server.Api.Models.Requests.Blog.PostCategoryRequests;

public record CreatePostCategoryRequest
{
    public string CategoryTitle { get; set; }
    public string CategoryIcon { get; set; }
}