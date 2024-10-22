using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for parameters to mint a token.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<MintTokenParams>))]
[PublicAPI]
public class MintTokenParams : GraphQlParameter<MintTokenParams>,
                               IHasEncodableTokenId<MintTokenParams>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MintTokenParams"/> class.
    /// </summary>
    public MintTokenParams()
    {
    }

    /// <summary>
    /// The initial supply of tokens to mint to the specified recipient. Must not exceed the token cap if set.
    /// </summary>
    /// <param name="amount">The amount to mint.</param>
    /// <returns>This parameter for chaining.</returns>
    public MintTokenParams SetAmount(BigInteger? amount)
    {
        return SetParameter("amount", amount);
    }
}