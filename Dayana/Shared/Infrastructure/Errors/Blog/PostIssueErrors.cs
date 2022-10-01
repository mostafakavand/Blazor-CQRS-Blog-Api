using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors.Blog;
public static class PostIssueErrors
{
    public static ErrorModel InvalidPostIssueIdError = new ErrorModel(
       code: 600,
       title: "Blog Error",
       (
           Language: Language.English,
           Message: "Invalid Post Issue Id"
       ));

    public static ErrorModel DuplicatePostCategoryCommentContextError = new ErrorModel(
        code: 601,
        title: "Blog Error",
        (
            Language: Language.English,
            Message: "Post Category Comment With This Context Exists"
        ));
}
