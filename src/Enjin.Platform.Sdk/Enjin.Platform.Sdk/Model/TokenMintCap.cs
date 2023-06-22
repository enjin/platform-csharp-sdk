using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for the token mint cap type and value.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<TokenMintCap>))]
[PublicAPI]
public class TokenMintCap : GraphQlParameter<TokenMintCap>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TokenMintCap"/> class.
    /// </summary>
    public TokenMintCap()
    {
    }

    /// <summary>
    /// The type of mint cap for this token.
    /// </summary>
    /// <param name="type">The cap type.</param>
    /// <returns>This parameter for chaining.</returns>
    public TokenMintCap SetType(TokenMintCapType? type)
    {
        return SetParameter("type", type);
    }

    /// <summary>
    /// The cap amount when using the <see cref="TokenMintCapType.Supply"/> type.
    /// </summary>
    /// <param name="amount">The cap amount.</param>
    /// <returns>This parameter for chaining.</returns>
    public TokenMintCap SetAmount(BigInteger? amount)
    {
        return SetParameter("amount", amount);
    }
}