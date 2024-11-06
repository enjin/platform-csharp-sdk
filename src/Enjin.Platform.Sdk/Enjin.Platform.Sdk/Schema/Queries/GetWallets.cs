using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for querying a wallet using either its database ID, external ID, verification ID or account address.
/// </summary>
/// <seealso cref="Wallet"/>
[PublicAPI]
public class GetWallets : GraphQlRequest<GetWallets, WalletConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetWallet"/> class.
    /// </summary>
    public GetWallets() : base("GetWallets", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the internal IDs for the wallet.
    /// </summary>
    /// <param name="ids">The internal IDs.</param>
    /// <returns>This request for chaining.</returns>
    public GetWallets SetIds(params int[]? ids)
    {
        return SetVariable("ids", CoreTypes.IntArray , ids);
    }

    /// <summary>
    /// Sets the external IDs for the wallet.
    /// </summary>
    /// <param name="externalIds">The external IDs.</param>
    /// <returns>This request for chaining.</returns>
    public GetWallets SetExternalIds(params string[]? externalIds)
    {
        return SetVariable("externalIds", CoreTypes.StringArray, externalIds);
    }

    /// <summary>
    /// Sets the verification IDs for the wallet.
    /// </summary>
    /// <param name="verificationIds">The verification IDs.</param>
    /// <returns>This request for chaining.</returns>
    public GetWallets SetVerificationIds(params string[]? verificationIds)
    {
        return SetVariable("verificationIds", CoreTypes.StringArray, verificationIds);
    }

    /// <summary>
    /// Sets the wallet accounts on the blockchain.
    /// </summary>
    /// <param name="accounts">The wallet accounts.</param>
    /// <returns>This request for chaining.</returns>
    public GetWallets SetAccounts(params string[]? accounts)
    {
        return SetVariable("accounts", CoreTypes.StringArray, accounts);
    }
    
    /// <summary>
    /// Set if the query should filter to managed wallets only.
    /// </summary>
    /// <param name="managed">The managed wallets filter.</param>
    /// <returns>This request for chaining.</returns>
    public GetWallets SetManaged(bool? managed)
    {
        return SetVariable("managed", CoreTypes.Boolean, managed);
    }
}