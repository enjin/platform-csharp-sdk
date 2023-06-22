using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models the balance properties of a <see cref="Wallet"/>.
/// </summary>
[PublicAPI]
public class Balances
{
    /// <summary>
    /// The amount free.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("free")]
    public BigInteger? Free { get; private set; }

    /// <summary>
    /// The amount reserved.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("reserved")]
    public BigInteger? Reserved { get; private set; }

    /// <summary>
    /// The amount frozen for miscellaneous reasons.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("miscFrozen")]
    public BigInteger? MiscFrozen { get; private set; }

    /// <summary>
    /// The amount frozen for pending fees.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("feeFrozen")]
    public BigInteger? FeeFrozen { get; private set; }
}