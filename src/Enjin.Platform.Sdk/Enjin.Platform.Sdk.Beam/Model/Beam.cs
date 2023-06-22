using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// Models a beam.
/// </summary>
[PublicAPI]
public class Beam
{
    /// <summary>
    /// The internal ID of this beam.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("id")]
    public BigInteger? Id { get; private set; }

    /// <summary>
    /// The code for this beam.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("code")]
    public string? Code { get; private set; }

    /// <summary>
    /// The name of this beam.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("name")]
    public string? Name { get; private set; }

    /// <summary>
    /// The description of this beam.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("description")]
    public string? Description { get; private set; }

    /// <summary>
    /// The image URL of this beam.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("image")]
    public string? Image { get; private set; }

    /// <summary>
    /// The start date claim period of this beam.
    /// </summary>
    [JsonConverter(typeof(NullableDateTimeJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("start")]
    public DateTime? Start { get; private set; }

    /// <summary>
    /// The end date claim period of this beam.
    /// </summary>
    [JsonConverter(typeof(NullableDateTimeJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("end")]
    public DateTime? End { get; private set; }

    /// <summary>
    /// The collection this beam belongs to.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("collection")]
    public Collection? Collection { get; private set; }

    /// <summary>
    /// The message of this beam.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("message")]
    public BeamScan? Message { get; private set; }

    /// <summary>
    /// Whether this beam is within its claim period.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("isClaimable")]
    public bool? IsClaimable { get; private set; }

    /// <summary>
    /// The flags for this beam.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("flags")]
    public IEnumerable<BeamFlag>? Flags { get; private set; }

    /// <summary>
    /// The QR URL for the claimable code of this beam.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("qr")]
    public BeamQr? Qr { get; private set; }
}