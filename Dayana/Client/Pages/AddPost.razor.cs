using Dayana.Shared.Persistence.Models.Blog.Requests;

namespace Dayana.Client.Pages;

public partial class AddPost
{
    CreatePostRequest model = new();

    async Task AddNewPost()
    {
        var b = model;
        try
        {
        }
        catch (Exception e)
        {

            throw new Exception(e.Message, e);
        }
    }
}
