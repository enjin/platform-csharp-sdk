using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// Models a beam claim.
/// </summary>
[PublicAPI]
public class BeamClaim
{
    /// <summary>
    /// The internal ID of this claim.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("id")]
    public int? Id { get; private set; }

    /// <summary>
    /// The collection details.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("collection")]
    public Collection? Collection { get; private set; }

    /// <summary>
    /// The token chain ID.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("tokenId")]
    public string? TokenId { get; private set; }

    /// <summary>
    /// The beam details.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("beam")]
    public Beam? Beam { get; private set; }

    /// <summary>
    /// The wallet account.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("wallet")]
    public Wallet? Wallet { get; private set; }

    /// <summary>
    /// The timestamp of the claim.
    /// </summary>
    [JsonConverter(typeof(NullableDateTimeJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("claimedAt")]
    public DateTime? ClaimedAt { get; private set; }

    /// <summary>
    /// The claim status.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("claimStatus")]
    public ClaimStatus? ClaimStatus { get; private set; }

    /// <summary>
    /// The beam type.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("type")]
    public BeamType? Type { get; private set; }

    /// <summary>
    /// The single use code.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("code")]
    public string? Code { get; private set; }

    /// <summary>
    /// The QR URL for the claimable code.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("qr")]
    public BeamQr? Qr { get; private set; }
}