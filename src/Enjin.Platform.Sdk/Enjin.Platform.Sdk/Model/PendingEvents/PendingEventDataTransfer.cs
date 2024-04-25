using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.PendingEvents;

/// <summary>
/// Models event data that has been broadcasted, but not yet acknowledged.
/// </summary>
[PublicAPI]
public class PendingEventDataTransfer : PendingEventDataBase
{
    /// <summary>
    /// The address this was sent to.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("to")]
    public string To { get; private set; }

    /// <summary>
    /// The address this was sent from.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("from")]
    public string From { get; private set; }

    /// <summary>
    /// The amount that was transferred.
    /// </summary>
    [JsonConverter(typeof(BigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("amount")]
    public BigInteger Amount { get; private set; }

    /// <summary>
    /// The transaction hash of the transfer.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("transactionHash")]
    public string TransactionHash { get; private set; }
}