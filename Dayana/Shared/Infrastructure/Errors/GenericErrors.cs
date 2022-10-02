using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors;
public static class GenericErrors<T>
{
    public static ErrorModel InvalidVariableError(string variableName) => new ErrorModel(
      code: 666,
      title: $"{nameof(T)} Error",
         (
        Language: Language.English,
        Message: $"Invalid property :{variableName} in {nameof(T)} error"
      ));
}
