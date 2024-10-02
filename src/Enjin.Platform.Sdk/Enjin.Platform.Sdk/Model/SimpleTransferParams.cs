using System;
using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for parameters to make a simple transfer.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<SimpleTransferParams>))]
[PublicAPI]
public class SimpleTransferParams : GraphQlParameter<SimpleTransferParams>,
                                    IHasEncodableTokenId<SimpleTransferParams>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SimpleTransferParams"/> class.
    /// </summary>
    public SimpleTransferParams()
    {
    }

    /// <summary>
    /// Sets the amount to transfer.
    /// </summary>
    /// <param name="amount">The amount.</param>
    /// <returns>This parameter for chaining.</returns>
    public SimpleTransferParams SetAmount(BigInteger? amount)
    {
        return SetParameter("amount", amount);
    }

    /// <summary>
    /// Sets whether the transaction will be kept from failing if the balance drops below the minimum requirement.
    /// </summary>
    /// <param name="keepAlive">Whether the transaction will be kept from failing.</param>
    /// <returns>This parameter for chaining.</returns>
    [Obsolete("This flag has been removed from the blockchain and will be ignored.")]
    public SimpleTransferParams SetKeepAlive(bool? keepAlive)
    {
        return SetParameter("keepAlive", keepAlive);
    }
}