using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors.Blog;
public static class PostCategoryIssueErrors
{
    public static ErrorModel InvalidPostCategoryIssueIdError = new ErrorModel(
       code: 600,
       title: "Blog Error",
       (
           Language: Language.English,
           Message: "Invalid Post Category Issue Id"
       ));

    public static ErrorModel DuplicatePostCategoryIssueContextError = new ErrorModel(
        code: 601,
        title: "Blog Error",
        (
            Language: Language.English,
            Message: "Post Category Issue With This Context Exists"
        ));
}
