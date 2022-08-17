using FluentValidation.Results;

namespace Dayana.Shared.Basic.MethodsAndObjects.Helpers;

public static class ValidationHelper
{
    public static string? GetFirstErrorMessage(this ValidationResult result)
    {
        return result.Errors.FirstOrDefault()?.ErrorMessage;
    }

    public static object? GetFirstErrorState(this ValidationResult result)
    {
        return result.Errors.FirstOrDefault()?.CustomState;
    }
}