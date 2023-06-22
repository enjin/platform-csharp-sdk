using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models the <see cref="Wallet"/> that has been approved to use the <see cref="CollectionAccount"/>.
/// </summary>
[PublicAPI]
public class CollectionAccountApproval
{
    /// <summary>
    /// The expiration block the wallet will lose its approval.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("expiration")]
    public int? Expiration { get; private set; }

    /// <summary>
    /// The collection account this approval belongs to.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("account")]
    public CollectionAccount? Account { get; private set; }

    /// <summary>
    /// The wallet that has been approved.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("wallet")]
    public Wallet? Wallet { get; private set; }
}