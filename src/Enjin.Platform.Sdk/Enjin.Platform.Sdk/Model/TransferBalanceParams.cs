using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// This model encapsulates the required parameters for a balance transfer.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<SimpleTransferParams>))]
[PublicAPI]
public class TransferBalanceParams : GraphQlParameter<TransferBalanceParams>,
                                    IHasEncodableTokenId<TransferBalanceParams>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TransferBalanceParams"/> class.
    /// </summary>
    public TransferBalanceParams()
    {
    }

    /// <summary>
    /// Sets the value to transfer.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>This parameter for chaining.</returns>
    public TransferBalanceParams SetValue(BigInteger value)
    {
        return SetParameter("value", value);
    }

    /// <summary>
    /// Sets whether the transaction will be kept from failing if the balance drops below the minimum requirement.
    /// </summary>
    /// <param name="keepAlive">Whether the transaction will be kept from failing.</param>
    /// <returns>This parameter for chaining.</returns>
    public TransferBalanceParams SetKeepAlive(bool? keepAlive)
    {
        return SetParameter("keepAlive", keepAlive);
    }
}