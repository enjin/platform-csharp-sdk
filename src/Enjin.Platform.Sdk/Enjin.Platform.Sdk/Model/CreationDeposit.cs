using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models the creation deposit properties of a <see cref="Token"/>.
/// </summary>
[PublicAPI]
public class CreationDeposit
{
    /// <summary>
    /// The depositor account.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("depositor")]
    public Wallet? Free { get; private set; }

    /// <summary>
    /// The amount deposited.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("amount")]
    public BigInteger? Amount { get; private set; }
}