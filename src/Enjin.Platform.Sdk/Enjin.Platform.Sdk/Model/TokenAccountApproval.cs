using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a <see cref="Wallet"/> that has been approved to use a <see cref="TokenAccount"/>.
/// </summary>
[PublicAPI]
public class TokenAccountApproval
{
    /// <summary>
    /// The amount the wallet has been approved.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("amount")]
    public BigInteger? Amount { get; private set; }

    /// <summary>
    /// The expiration block the wallet will lose the approval.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("expiration")]
    public int? Expiration { get; private set; }

    /// <summary>
    /// The token account this approval belongs to.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("account")]
    public TokenAccount? Account { get; private set; }

    /// <summary>
    /// The wallet that has been approved.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("wallet")]
    public Wallet? Wallet { get; private set; }
}