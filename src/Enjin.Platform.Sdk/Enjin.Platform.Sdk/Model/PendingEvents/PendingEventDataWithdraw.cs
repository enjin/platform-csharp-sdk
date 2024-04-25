using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.PendingEvents;

/// <summary>
/// Models event data that has been broadcasted, but not yet acknowledged.
/// </summary>
[PublicAPI]
public class PendingEventDataWithdraw : PendingEventDataBase
{
    /// <summary>
    /// The account that withdrew
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("who")]
    public string Who { get; private set; }

    /// <summary>
    /// The amount that was withdrawn
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("amount")]
    [JsonConverter(typeof(BigIntegerJsonConverter))]
    public BigInteger Amount { get; private set; }
}