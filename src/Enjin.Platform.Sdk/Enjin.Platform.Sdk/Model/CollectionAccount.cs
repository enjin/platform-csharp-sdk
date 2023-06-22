using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models an account for a <see cref="Collection"/>.
/// </summary>
/// <remarks>
/// A collection account groups together a wallet's token accounts for a given collection and controls options such as
/// freezing and approvals for all tokens in them.
/// </remarks>
[PublicAPI]
public class CollectionAccount
{
    /// <summary>
    /// The number of token accounts attached to this collection account.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("accountCount")]
    public int? AccountCount { get; private set; }

    /// <summary>
    /// Specifies if this collection account is frozen.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("isFrozen")]
    public bool? IsFrozen { get; private set; }

    /// <summary>
    /// The collection this collection account belongs to.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("collection")]
    public Collection? Collection { get; private set; }

    /// <summary>
    /// The wallet which owns this collection account.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("wallet")]
    public Wallet? Wallet { get; private set; }

    /// <summary>
    /// The list of approvals for this collection account.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("approvals")]
    public IEnumerable<CollectionAccountApproval>? Approvals { get; private set; }
}