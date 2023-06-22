using System.Collections.Generic;
using System.Numerics;
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
public class Collection
{
    /// <summary>
    /// The ID assigned to this collection.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("collectionId")]
    public BigInteger? CollectionId { get; private set; }

    /// <summary>
    /// The maximum number of tokens that can be issued for this collection.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("maxTokenCount")]
    public int? MaxTokenCount { get; private set; }

    /// <summary>
    /// The maximum amount of each token in this collection that may be minted.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("maxTokenSupply")]
    public BigInteger? MaxTokenSupply { get; private set; }

    /// <summary>
    /// Whether the tokens in this collection will be minted as single mint types.
    /// </summary>
    /// <remarks>
    /// This would indicate the tokens in this collection are non-fungible.
    /// </remarks>
    [JsonInclude]
    [JsonPropertyName("forceSingleMint")]
    public bool? ForceSingleMint { get; private set; }

    /// <summary>
    /// Whether this collection is frozen.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("frozen")]
    public bool? Frozen { get; private set; }

    /// <summary>
    /// The royalty policy for this collection.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("royalty")]
    public Royalty? Royalty { get; private set; }

    /// <summary>
    /// The network this collection belongs to.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("network")]
    public string? Network { get; private set; }

    /// <summary>
    /// The wallet which can mint tokens from this collection.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("owner")]
    public Wallet? Owner { get; private set; }

    /// <summary>
    /// The attributes for this collection.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("attributes")]
    public IEnumerable<Attribute>? Attributes { get; private set; }

    /// <summary>
    /// The accounts for this collection.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("accounts")]
    public Connection<CollectionAccount>? Accounts { get; private set; }

    /// <summary>
    /// The tokens minted from this collection.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("tokens")]
    public Connection<Token>? Tokens { get; private set; }
}