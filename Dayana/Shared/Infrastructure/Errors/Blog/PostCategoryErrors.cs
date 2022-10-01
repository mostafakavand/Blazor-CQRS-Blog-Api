using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors.Blog;
public static class PostCategoryErrors
{
    public static ErrorModel InvalidPostCategorydError = new ErrorModel(
       code: 600,
       title: "Blog Error",
       (
           Language: Language.English,
           Message: "Invalid Post Category  Id"
       ));

    public static ErrorModel DuplicatePostCategoryCommentContextError = new ErrorModel(
        code: 601,
        title: "Blog Error",
        (
            Language: Language.English,
            Message: "Post Category Comment With This Context Exists"
        ));

    public static ErrorModel DuplicatePostCategoryCommentContextError = new ErrorModel(
       code: 601,
       title: "Blog Error",
       (
           Language: Language.English,
           Message: "Post Category Comment With This Context Exists"
       ));
}
