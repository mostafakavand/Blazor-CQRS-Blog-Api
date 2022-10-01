using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors.Blog;
public static class PostCommentErros
{
    public static ErrorModel InvalidPostCommentIdError = new ErrorModel(
       code: 600,
       title: "Blog Error",
       (
           Language: Language.English,
           Message: "Invalid Post Comment Id"
       ));

    public static ErrorModel DuplicatePostCommentContextError = new ErrorModel(
        code: 601,
        title: "Blog Error",
        (
            Language: Language.English,
            Message: "Post Comment With This Context Exists"
        ));
}
