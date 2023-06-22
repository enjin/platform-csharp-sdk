using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a blockchain wallet.
/// </summary>
[PublicAPI]
public class Wallet
{
    /// <summary>
    /// The internal ID of this wallet.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("id")]
    public int? Id { get; private set; }

    /// <summary>
    /// The account of this wallet.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("account")]
    public Account? Account { get; private set; }

    /// <summary>
    /// The external ID associated with this wallet.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; private set; }

    /// <summary>
    /// Whether this is a managed wallet.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("managed")]
    public bool? Managed { get; private set; }

    /// <summary>
    /// The blockchain network this wallet belongs to.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("network")]
    public string? Network { get; private set; }

    /// <summary>
    /// The nonce of the account.
    /// </summary>
    /// <remarks>
    /// This property may be <c>null</c> if this wallet does not exist on the blockchain.
    /// </remarks>
    [JsonInclude]
    [JsonPropertyName("nonce")]
    public int? Nonce { get; private set; }

    /// <summary>
    /// The EFI balance of the account.
    /// </summary>
    /// <remarks>
    /// This property will be <c>null</c> if this wallet does not exist on the blockchain.
    /// </remarks>
    [JsonInclude]
    [JsonPropertyName("balances")]
    public Balances? Balances { get; private set; }

    /// <summary>
    /// The collection accounts this Wallet has.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("collectionAccounts")]
    public Connection<CollectionAccount>? CollectionAccounts { get; private set; }

    /// <summary>
    /// The token accounts this wallet owns.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("tokenAccounts")]
    public Connection<TokenAccount>? TokenAccounts { get; private set; }

    /// <summary>
    /// The collection account approvals this wallet has.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("collectionAccountApprovals")]
    public Connection<CollectionAccountApproval>? CollectionAccountApprovals { get; private set; }

    /// <summary>
    /// The token account approvals this wallet has.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("tokenAccountApprovals")]
    public Connection<TokenAccountApproval>? TokenAccountApprovals { get; private set; }

    /// <summary>
    /// The transactions performed by this wallet.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("transactions")]
    public Connection<Transaction>? Transactions { get; private set; }

    /// <summary>
    /// The collections this wallet owns.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("ownedCollections")]
    public Connection<Collection>? OwnedCollections { get; private set; }
}