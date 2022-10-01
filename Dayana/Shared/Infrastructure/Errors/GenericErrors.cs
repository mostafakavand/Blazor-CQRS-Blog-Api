using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors;
public static class GenericErrors<T>
{
    public static ErrorModel InvalidIdError = new ErrorModel(
      code: 100,
      title: "Identity Error",
      (
          Language: Language.English,
          Message: $"Invalid {nameof(T)} id error"
      ));

    public static ErrorModel InvalidNameError = new ErrorModel(
     code: 101,
     title: "Identity Error",
     (
         Language: Language.English,
         Message: $"Invalid {nameof(T)} name error"
     ));

    public static ErrorModel InvalidTitleError = new ErrorModel(
     code: 102,
     title: "Identity Error",
        (
       Language: Language.English,
       Message: $"Invalid {nameof(T)} title error"
     ));

    public static ErrorModel InvalidVariableError(string variableName) => new ErrorModel(
     code: 102,
     title: "Identity Error",
        (
       Language: Language.English,
       Message: $"Invalid property :{variableName} in {nameof(T)} error"
     ));
}
