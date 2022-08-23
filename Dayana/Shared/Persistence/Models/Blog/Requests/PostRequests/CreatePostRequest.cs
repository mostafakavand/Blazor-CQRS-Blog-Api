namespace Dayana.Shared.Persistence.Models.Blog.Requests.PostRequests;

public class CreatePostRequest
{
    public string Title { get; set; }
    public string Summery { get; set; }
    public string TextContent { get; set; }
}