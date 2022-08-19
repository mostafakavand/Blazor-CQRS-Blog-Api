using Dayana.Shared.Basic.MethodsAndObjects.Models;

namespace Dayana.Shared.Basic.MethodsAndObjects.Helpers;

public static class PartialUpdate<T>
{
    public static T? Run(T sourceProperty, T inputProperty, PartialUpdateOperand op)
    {
        if (op == PartialUpdateOperand.Replace) return inputProperty;
        if (op == PartialUpdateOperand.Remove) return default;
        return default;
    }
}