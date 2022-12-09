using Dayana.Shared.Persistence.Models.Blog.Requests;
using System.Net.Http.Json;

namespace Dayana.Client.Pages;

public partial class AddPost
{
    CreatePostRequest model = new();

    async Task AddNewPost()
    {
        var b = model;
        try
        {
            var cb = await _httpClient.PostAsJsonAsync("api/post/add", model);
        }
        catch (Exception e)
        {

            throw new Exception(e.Message, e);
        }
    }
}
