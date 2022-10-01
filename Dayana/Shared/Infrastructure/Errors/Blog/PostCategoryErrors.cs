using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors.Blog;
//700-799
public static class PostCategoryErrors
{
    public static ErrorModel InvalidPostCategoryIdError = new ErrorModel(
       code: 700,
       title: "Blog Error",
       (
           Language: Language.English,
           Message: "Invalid Post Category Id"
       ));

    public static ErrorModel DuplicatePostCategoryContextError = new ErrorModel(
        code: 701,
        title: "Blog Error",
        (
            Language: Language.English,
            Message: "Post Category With This Context Exists"
        ));
}
