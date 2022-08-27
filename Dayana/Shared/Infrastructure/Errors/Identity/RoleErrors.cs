using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors.Identity;
// 400 - 499
public static class RoleErrors
{
    public static ErrorModel RoleNotFoundError = new ErrorModel(
        code: 400,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Role not found"
        ));

    public static ErrorModel DuplicateTitleError = new ErrorModel(
        code: 401,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Title is registered before"
        ));
}