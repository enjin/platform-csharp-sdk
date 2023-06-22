using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models an event parameter.
/// </summary>
[PublicAPI]
public class EventParam
{
    /// <summary>
    /// The value type of this parameter.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("type")]
    public string? Type { get; private set; }

    /// <summary>
    /// The JSON value of this parameter.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("value")]
    public JsonElement? Value { get; private set; }
}