using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors.Identity;
// 500 -599
public static class UserErrors
{
    public static ErrorModel UserNotFoundError = new ErrorModel(
        code: 500,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "User not found"
        ));

    public static ErrorModel DuplicateUsernameError = new ErrorModel(
        code: 501,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Username is registered before"
        ));

    public static ErrorModel InvalidUserIdValidationError = new ErrorModel(
        code: 502,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid user id"
        ));

    public static ErrorModel InvalidUsernameValidationError = new ErrorModel(
        code: 503,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid username"
        ));

    public static ErrorModel InvalidEmailValidationError = new ErrorModel(
        code: 504,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid email address"
        ));

    public static ErrorModel InvalidMobileValidationError = new ErrorModel(
        code: 505,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid mobile"
        ));

    public static ErrorModel InvalidPasswordValidationError = new ErrorModel(
        code: 506,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Password is not provided"
        ));

    public static ErrorModel InvalidFirstNameValidationError = new ErrorModel(
        code: 507,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid first name"
        ));

    public static ErrorModel InvalidLastNameValidationError = new ErrorModel(
        code: 508,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid last name"
        ));
    public static ErrorModel InvalidPhoneNumberValidationError = new ErrorModel(
        code: 509,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid phone number"
        ));

    public static ErrorModel InvalidFullNameValidationError = new ErrorModel(
       code: 510,
       title: "Identity Error",
       (
           Language: Language.English,
           Message: "Invalid full name"
       ));

    public static ErrorModel InvalidAccessTokenValidationError = new ErrorModel(
      code: 510,
      title: "Identity Error",
      (
          Language: Language.English,
          Message: "Invalid access token"
      ));
}