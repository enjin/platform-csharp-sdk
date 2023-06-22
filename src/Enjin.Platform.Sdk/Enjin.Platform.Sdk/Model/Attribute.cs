using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models an on-chain key and value pair.
/// </summary>
[PublicAPI]
public class Attribute
{
    /// <summary>
    /// The key of this attribute.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("key")]
    public string? Key { get; private set; }

    /// <summary>
    /// The value of this attribute.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("value")]
    public string? Value { get; private set; }
}