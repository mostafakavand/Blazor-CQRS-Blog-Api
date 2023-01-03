using Dayana.Shared.Infrastructure.Routes;
using Dayana.Shared.Persistence.HttpObjects;
using Dayana.Shared.Persistence.Models.Blog.Requests;
using Microsoft.AspNetCore.Components;

namespace Dayana.Client.Pages.Blog.PostCategory;

public partial class AddPostCategory
{
    CreatePostCategoryRequest model = new();

    async Task AddNewPost()
    {
        var response = await _httpService.PostValue(BlogRoutes.PostCategory + "add", model);
        var aa = response;
    }
}
