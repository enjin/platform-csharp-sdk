using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A request to act as a mutation for removing tokens from a beam.
/// </summary>
[PublicAPI]
public class RemoveTokens : GraphQlRequest<RemoveTokens>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveTokens"/> class.
    /// </summary>
    public RemoveTokens() : base("RemoveTokens", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the code of the beam.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveTokens SetCode(string? code)
    {
        return SetVariable("code", CoreTypes.String, code);
    }

    /// <summary>
    /// Sets the token IDs to remove.
    /// </summary>
    /// <param name="tokenIds">The token IDs.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveTokens SetTokenIds(params IntegerRangeString[]? tokenIds)
    {
        return SetVariable("tokenIds", CoreTypes.IntegerRangeStringArray, tokenIds);
    }
}