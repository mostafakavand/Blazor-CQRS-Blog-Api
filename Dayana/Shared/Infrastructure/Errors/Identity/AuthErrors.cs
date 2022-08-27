using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors.Identity;

// 100 - 199
public static class AuthErrors
{
    public static ErrorModel InvalidLoginError = new ErrorModel(
        code: 100,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid login information"
        ));

    public static ErrorModel InvalidCredentialsError = new ErrorModel(
        code: 101,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid credentials"
        ));

    public static ErrorModel UnauthorizedRequestError = new ErrorModel(
        code: 102,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Unauthorized request"
        ));
}