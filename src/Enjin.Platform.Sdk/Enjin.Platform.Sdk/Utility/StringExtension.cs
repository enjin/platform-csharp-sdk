namespace Enjin.Platform.Sdk;

/// <summary>
/// Static class with extension methods for <see cref="string"/>.
/// </summary>
internal static class StringExtension
{
    /// <summary>
    /// Performs the inverse operation of <see cref="string.Equals(string)"/>.
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <param name="value">The string to compare to the source.</param>
    /// <returns>
    /// <c>false</c> if the value of the value parameter is the same as the value of the source; otherwise, <c>true</c>.
    /// If value is <c>null</c>, the method returns <c>true</c>.
    /// </returns>
    public static bool NotEquals(this string source, string value)
    {
        return !source.Equals(value);
    }
}