using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors.Identity;
// 300 - 399
public static class PermissionErrors
{
    public static ErrorModel InvalidPermissionIdValidationError = new ErrorModel(
        code: 300,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid permission id"
        ));

    public static ErrorModel InvalidClaimIdValidationError = new ErrorModel(
        code: 301,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid permission id"
        ));

    public static ErrorModel DuplicateClaimError = new ErrorModel(
        code: 302,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Claim is registered before"
        ));

    public static ErrorModel ClaimNotFoundError = new ErrorModel(
        code: 303,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Claim not found"
        ));


}