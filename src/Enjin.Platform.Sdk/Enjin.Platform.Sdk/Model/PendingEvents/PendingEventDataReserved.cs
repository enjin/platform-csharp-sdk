using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.PendingEvents;

/// <summary>
/// Models event data that has been broadcasted, but not yet acknowledged.
/// </summary>
[PublicAPI]
public class PendingEventDataReserved : PendingEventDataBase
{
    /// <summary>
    /// The address this was sent to.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("who")]
    public string? Who { get; private set; }

    /// <summary>
    /// The amount that was reserved.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("amount")]
    [JsonConverter(typeof(BigIntegerJsonConverter))]
    public BigInteger Amount { get; private set; }
}