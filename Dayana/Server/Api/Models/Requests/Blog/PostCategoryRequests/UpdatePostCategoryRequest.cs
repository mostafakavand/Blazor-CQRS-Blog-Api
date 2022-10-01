namespace Dayana.Server.Api.Models.Requests.Blog.PostCategoryRequests;

public record UpdatePostCategoryRequest
{
    public string CategoryTitle { get; set; }
    public string CategoryIcon { get; set; }
}