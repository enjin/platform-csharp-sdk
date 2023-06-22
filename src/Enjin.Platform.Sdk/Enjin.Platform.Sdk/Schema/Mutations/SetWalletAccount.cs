using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for setting the account on a wallet model.
/// </summary>
[PublicAPI]
public class SetWalletAccount : GraphQlRequest<SetWalletAccount>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SetWalletAccount"/> class.
    /// </summary>
    public SetWalletAccount() : base("SetWalletAccount", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the internal ID of the wallet.
    /// </summary>
    /// <param name="id">The internal ID.</param>
    /// <returns>This request for chaining.</returns>
    public SetWalletAccount SetId(int? id)
    {
        return SetVariable("id", CoreTypes.Int, id);
    }

    /// <summary>
    /// Sets the external ID for this wallet.
    /// </summary>
    /// <param name="externalId">The external ID.</param>
    /// <returns>This request for chaining.</returns>
    public SetWalletAccount SetExternalId(string? externalId)
    {
        return SetVariable("externalId", CoreTypes.String, externalId);
    }

    /// <summary>
    /// Sets the wallet account on the blockchain.
    /// </summary>
    /// <param name="account">The wallet account.</param>
    /// <returns>This request for chaining.</returns>
    public SetWalletAccount SetAccount(string? account)
    {
        return SetVariable("account", CoreTypes.String, account);
    }
}