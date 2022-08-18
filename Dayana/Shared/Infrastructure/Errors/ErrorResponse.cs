using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors;

public class ErrorResponse
{
    private const string EnglishLanguage = "en";
    private const string DutchLanguage = "nl";
    private const string PersianLanguage = "fa";

    public ErrorResponse(ErrorModel error, string language = null)
    {
        Code = error.Code;
        Title = error.Title;
        Message = language switch
        {
            EnglishLanguage => error.Messages[Language.English],
            DutchLanguage => error.Messages[Language.Dutch],
            PersianLanguage => error.Messages[Language.Persian],
            _ => error.Messages[Language.English]
        };
    }

    public int Code { get; }
    public string Title { get; }
    public string Message { get; }
}