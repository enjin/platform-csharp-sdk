using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a pallet that has reserved some tokens and the amount.
/// </summary>
[PublicAPI]
public class TokenAccountNamedReserve
{
    /// <summary>
    /// The pallet that has created this reserve.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("pallet")]
    public PalletIdentifier? Pallet { get; private set; }

    /// <summary>
    /// The amount in the wallet that has been reserved.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("amount")]
    public BigInteger? Amount { get; private set; }
}