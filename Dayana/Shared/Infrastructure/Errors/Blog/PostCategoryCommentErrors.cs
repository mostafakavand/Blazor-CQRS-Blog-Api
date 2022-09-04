using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors.Blog;

// 600 - 699
public static class PostCategoryCommentErrors
{
    public static ErrorModel InvalidPostCategoryCommentIdError = new ErrorModel(
        code: 600,
        title: "Blog Error",
        (
            Language: Language.English,
            Message: "Invalid Post Category Comment Id"
        ));

    public static ErrorModel DuplicatePostCategoryContextError = new ErrorModel(
        code: 601,
        title: "Blog Error",
        (
            Language: Language.English,
            Message: "Post Category Comment With This Context Exists"
        ));

}
