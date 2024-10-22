using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A request to act as a mutation for adding tokens to a beam.
/// </summary>
[PublicAPI]
public class AddTokens : GraphQlRequest<AddTokens>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddTokens"/> class.
    /// </summary>
    public AddTokens() : base("AddTokens", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the code of the beam.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <returns>This request for chaining.</returns>
    public AddTokens SetCode(string? code)
    {
        return SetVariable("code", CoreTypes.String, code);
    }

    /// <summary>
    /// Sets the token IDs to add.
    /// </summary>
    /// <param name="tokenIds">The token claims to add.</param>
    /// <returns>This request for chaining.</returns>
    public AddTokens SetTokens(params ClaimToken[]? tokenIds)
    {
        return SetVariable("tokens", BeamTypes.ClaimTokenArray, tokenIds);
    }
}