using System.Collections.Generic;
using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a token account, which stores the balances of tokens.
/// </summary>
[PublicAPI]
public class TokenAccount
{
    /// <summary>
    /// The balance of the token this account holds.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("balance")]
    public BigInteger? Balance { get; private set; }

    /// <summary>
    /// The reserved value for this account.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("reservedBalance")]
    public BigInteger? ReservedBalance { get; private set; }

    /// <summary>
    /// Whether this account is frozen, disallowing transfers.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("isFrozen")]
    public bool? IsFrozen { get; private set; }

    /// <summary>
    /// The collection this account belongs to.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("collection")]
    public Collection? Collection { get; private set; }

    /// <summary>
    /// The wallet which owns this account.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("wallet")]
    public Wallet? Wallet { get; private set; }

    /// <summary>
    /// The token for this account.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("token")]
    public Token? Token { get; private set; }

    /// <summary>
    /// The list of approvals for this account.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("approvals")]
    public IEnumerable<TokenAccountApproval>? Approvals { get; private set; }

    /// <summary>
    /// The list of the named reserves for this account.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("namedReserves")]
    public IEnumerable<TokenAccountNamedReserve>? NamedReserves { get; private set; }
}