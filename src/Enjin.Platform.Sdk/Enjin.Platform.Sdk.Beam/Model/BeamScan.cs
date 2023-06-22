using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// Models a beam scan.
/// </summary>
[PublicAPI]
public class BeamScan
{
    /// <summary>
    /// The internal ID of this scan.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("id")]
    public BigInteger? Id { get; private set; }

    /// <summary>
    /// The wallet public key.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("walletPublicKey")]
    public string? WalletPublicKey { get; private set; }

    /// <summary>
    /// The message to sign.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("message")]
    public string? Message { get; private set; }
}