﻿using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a token on the blockchain.
/// </summary>
[PublicAPI]
public class Token
{
    /// <summary>
    /// The token chain ID which is a 128-bit unsigned integer.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("tokenId")]
    public BigInteger? TokenId { get; private set; }

    /// <summary>
    /// The current supply of this token.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("supply")]
    public BigInteger? Supply { get; private set; }

    /// <summary>
    /// The quantity setting for this token.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("cap")]
    public TokenMintCapType? Cap { get; private set; }

    /// <summary>
    /// The maximum quantity available for this token.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("capSupply")]
    public BigInteger? CapSupply { get; private set; }

    /// <summary>
    /// Specifies if this token is frozen, disallowing transfers.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("isFrozen")]
    public bool? IsFrozen { get; private set; }

    /// <summary>
    /// Whether this token is a currency (fungible).
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("isCurrency")]
    public bool? IsCurrency { get; private set; }

    /// <summary>
    /// The token royalty if set, or <c>null</c> if not.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("royalty")]
    public Royalty? Royalty { get; private set; }
    
    /// <summary>
    /// The number of attributes set on this token.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("attributeCount")]
    public int? AttributeCount { get; private set; }
    
    /// <summary>
    /// Whether this token requires a deposit.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("requiresDeposit")]
    public bool? RequiresDeposit { get; private set; }
    
    /// <summary>
    /// The creation deposit for this token.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("creationDeposit")]
    public CreationDeposit? CreationDeposit { get; private set; }

    /// <summary>
    /// The owner deposit for this token.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("ownerDeposit")]
    public BigInteger? OwnerDeposit { get; private set; }
    
    /// <summary>
    /// The total amount of deposit required.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("totalTokenAccountDeposit")]
    public BigInteger? TotalTokenAccountDeposit { get; private set; }
    
    /// <summary>
    /// The amount of ENJ to infuse into each token.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("infusion")]
    public BigInteger? Infusion { get; private set; }
    
    /// <summary>
    /// Whether anyone can infuse ENJ into this token.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("anyoneCanInfuse")]
    public bool? AnyoneCanInfuse { get; private set; }
    
    /// <summary>
    /// The token metadata.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("tokenMetadata")]
    public TokenMetadata? TokenMetadata { get; private set; }
    
    /// <summary>
    /// The collection this token belongs to.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("collection")]
    public Collection? Collection { get; private set; }

    /// <summary>
    /// The attributes for this token.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("attributes")]
    public IEnumerable<Attribute>? Attributes { get; private set; }

    /// <summary>
    /// The token accounts that hold this token.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("accounts")]
    public Connection<TokenAccount>? Accounts { get; private set; }

    /// <summary>
    /// The metadata for this token.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("metadata")]
    public JsonElement? Metadata { get; private set; }

    /// <summary>
    /// Shows if this token is considered non-fungible (i.e. there is only one available and therefore truly unique).
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("nonFungible")]
    public bool? NonFungible { get; private set; }
}