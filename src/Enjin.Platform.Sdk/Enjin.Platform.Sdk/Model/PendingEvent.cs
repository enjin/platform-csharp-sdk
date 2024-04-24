using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a collection on the platform.
/// </summary>
/// <remarks>
/// A collection groups together tokens and sets the policies that apply to them.
/// </remarks>
[PublicAPI]
public class PendingEvent
{
    /// <summary>
    /// The ID assigned to this pending event.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("id")]
    public BigInteger? Id { get; private set; }

    /// <summary>
    /// The uuid assigned to this pending event.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("uuid")]
    public string? Uuid { get; private set; }

    /// <summary>
    /// The name of the event.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("name")]
    public string? Name { get; private set; }

    /// <summary>
    /// When this event was sent.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("sent")]
    public string? Sent { get; private set; }

    /// <summary>
    /// The channels this event was sent to.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("channels")]
    public IEnumerable<string>? Channels { get; private set; }

    /// <summary>
    /// The data payload for this event.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("data")]
    public JsonElement? Data { get; private set; }
}