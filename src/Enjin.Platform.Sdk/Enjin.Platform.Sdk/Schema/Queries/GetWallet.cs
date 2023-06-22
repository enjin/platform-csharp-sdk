using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for querying a wallet using either its database ID, external ID, verification ID or account address.
/// </summary>
/// <seealso cref="Wallet"/>
[PublicAPI]
public class GetWallet : GraphQlRequest<GetWallet, WalletFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetWallet"/> class.
    /// </summary>
    public GetWallet() : base("GetWallet", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the internal ID for the wallet.
    /// </summary>
    /// <param name="id">The internal ID.</param>
    /// <returns>This request for chaining.</returns>
    public GetWallet SetId(int? id)
    {
        return SetVariable("id", CoreTypes.Int, id);
    }

    /// <summary>
    /// Sets the external ID for the wallet.
    /// </summary>
    /// <param name="externalId">The external ID.</param>
    /// <returns>This request for chaining.</returns>
    public GetWallet SetExternalId(string? externalId)
    {
        return SetVariable("externalId", CoreTypes.String, externalId);
    }

    /// <summary>
    /// Sets the verification ID for the wallet.
    /// </summary>
    /// <param name="verificationId">The verification ID.</param>
    /// <returns>This request for chaining.</returns>
    public GetWallet SetVerificationId(string? verificationId)
    {
        return SetVariable("verificationId", CoreTypes.String, verificationId);
    }

    /// <summary>
    /// Sets the wallet account on the blockchain.
    /// </summary>
    /// <param name="account">The wallet account.</param>
    /// <returns>This request for chaining.</returns>
    public GetWallet SetAccount(string? account)
    {
        return SetVariable("account", CoreTypes.String, account);
    }
}