using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for parameters that can be mutated for a token.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<TokenMutationInput>))]
[PublicAPI]
public class TokenMutationInput : GraphQlParameter<TokenMutationInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TokenMutationInput"/> class.
    /// </summary>
    public TokenMutationInput()
    {
    }

    /// <summary>
    /// Sets the market behavior of the token.
    /// </summary>
    /// <param name="behavior">The behavior.</param>
    /// <returns>This parameter for chaining.</returns>
    public TokenMutationInput SetBehavior(TokenMarketBehaviorInput? behavior)
    {
        return SetParameter("behavior", behavior);
    }

    /// <summary>
    /// Sets whether the token can be listed in the marketplace.
    /// </summary>
    /// <param name="listingForbidden">Whether the token can be listed in the marketplace.</param>
    /// <returns>This parameter for chaining.</returns>
    public TokenMutationInput SetListingForbidden(bool? listingForbidden)
    {
        return SetParameter("listingForbidden", listingForbidden);
    }
}