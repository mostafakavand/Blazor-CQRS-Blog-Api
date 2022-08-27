using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors.Identity;

// 200 - 299
public static class CommonErrors
{
    public static ErrorModel InvalidInputValidationError = new ErrorModel(
        code: 200,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid input"
        ));

    public static ErrorModel InvalidNameValidationError = new ErrorModel(
        code: 201,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid name"
        ));

    public static ErrorModel InvalidLatinNameValidationError = new ErrorModel(
        code: 203,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid name latin"
        ));

    public static ErrorModel InvalidTitleValidationError = new ErrorModel(
        code: 204,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid title"
        ));

    public static ErrorModel InvalidPostalCodeValidationError = new ErrorModel(
        code: 205,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid postal code"
        ));

    public static ErrorModel InvalidAddressValidationError = new ErrorModel(
        code: 206,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid address"
        ));

}