using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a blockchain event.
/// </summary>
[PublicAPI]
public class Event
{
    /// <summary>
    /// The phase of blockchain execution if it happened for this event.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("phase")]
    public int? Phase { get; private set; }

    /// <summary>
    /// The method lookup of this event.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("lookUp")]
    public string? Lookup { get; private set; }

    /// <summary>
    /// The pallet module of this event.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("moduleId")]
    public string? ModuleId { get; private set; }

    /// <summary>
    /// The ID of this event.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("eventId")]
    public string? EventId { get; private set; }

    /// <summary>
    /// The parameters from this event.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("params")]
    public IEnumerable<EventParam>? Params { get; private set; }
}