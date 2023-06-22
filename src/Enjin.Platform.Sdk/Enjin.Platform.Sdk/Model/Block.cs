using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a blockchain block.
/// </summary>
[PublicAPI]
public class Block
{
    /// <summary>
    /// The internal ID of this block.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("id")]
    public int? Id { get; private set; }

    /// <summary>
    /// The on-chain block number.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("number")]
    public BigInteger? Number { get; private set; }

    /// <summary>
    /// The on-chain block hash.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("number")]
    public string? Hash { get; private set; }

    /// <summary>
    /// Whether this block was already synced.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("number")]
    public bool? Synced { get; private set; }

    /// <summary>
    /// Whether this block failed to be processed.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("number")]
    public bool? Failed { get; private set; }

    /// <summary>
    /// The exception that happened when processing this block, if one exists.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("number")]
    public string? Exception { get; private set; }
}