using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for the market behavior for a token.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<TokenMarketBehaviorInput>))]
[PublicAPI]
public class TokenMarketBehaviorInput : GraphQlParameter<TokenMarketBehaviorInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TokenMarketBehaviorInput"/> class.
    /// </summary>
    public TokenMarketBehaviorInput()
    {
    }

    /// <summary>
    /// Sets the royalty settings for the market behavior.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>This parameter for chaining.</returns>
    public TokenMarketBehaviorInput SetHasRoyalty(RoyaltyInput? input)
    {
        return SetParameter("hasRoyalty", input);
    }

    /// <summary>
    /// Sets whether the token is a currency.
    /// </summary>
    /// <param name="isCurrency">Whether the token is a currency.</param>
    /// <returns>This parameter for chaining.</returns>
    public TokenMarketBehaviorInput SetIsCurrency(bool? isCurrency)
    {
        return SetParameter("isCurrency", isCurrency);
    }
}