using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models the token metadata properties of a <see cref="Token"/>.
/// </summary>
[PublicAPI]
public class TokenMetadata
{
    /// <summary>
    /// The token name.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("name")]
    public string? Name { get; private set; }

    /// <summary>
    /// The token symbol.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("symbol")]
    public string? Symbol { get; private set; }

    /// <summary>
    /// The token decimal count.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("decimalCount")]
    public int? DecimalCount { get; private set; }
}