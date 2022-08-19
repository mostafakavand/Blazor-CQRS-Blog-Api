namespace Dayana.Server.Api.Models.Requests.Blog.PostRequests;

public class CreatePostRequest
{
    public string Title { get; set; }
    public string Summery { get; set; }
    public string TextContent { get; set; }
}