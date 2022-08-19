namespace Dayana.Shared.Basic.MethodsAndObjects.Helpers;

public sealed class StampGenerator
{
    public static string CreateSecurityStamp(int length)
    {
        return RandomGenerator
            .GenerateString(length, AllowedCharacters.Alphanumeric)
            .ToUpper();
    }
}