using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface for compilable GraphQL types.
/// </summary>
[PublicAPI]
public interface IGraphQlCompilable
{
    /// <summary>
    /// Compiles this GraphQL type and returns it as a string.
    /// </summary>
    /// <returns>The compiled string.</returns>
    public string Compile();
}