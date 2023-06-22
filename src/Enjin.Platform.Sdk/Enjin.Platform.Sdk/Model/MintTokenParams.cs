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

    /// <summary>
    /// Sets the price of each token.
    /// </summary>
    /// <param name="unitPrice">The price per token.</param>
    /// <returns>This parameter for chaining.</returns>
    /// <remarks>
    /// Leave as null if you want to keep the same unitPrice. You can also put a value if you want to change the
    /// unit price. Please note you can only increase it and a deposit to the difference of every token previously
    /// minted will also be needed.
    /// </remarks>
    public MintTokenParams SetUnitPrice(BigInteger? unitPrice)
    {
        return SetParameter("unitPrice", unitPrice);
    }
}