using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for changing the external ID on a wallet model.
/// </summary>
[PublicAPI]
public class UpdateWalletExternalId : GraphQlRequest<UpdateWalletExternalId>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateWalletExternalId"/> class.
    /// </summary>
    public UpdateWalletExternalId() : base("UpdateWalletExternalId", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the internal ID of the wallet.
    /// </summary>
    /// <param name="id">The internal ID.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateWalletExternalId SetId(int? id)
    {
        return SetVariable("id", CoreTypes.Int, id);
    }

    /// <summary>
    /// Sets the external ID for the wallet.
    /// </summary>
    /// <param name="externalId">The external ID.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateWalletExternalId SetExternalId(string? externalId)
    {
        return SetVariable("externalId", CoreTypes.String, externalId);
    }

    /// <summary>
    /// Sets the new external ID to set for the wallet.
    /// </summary>
    /// <param name="newExternalId">The new external ID.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateWalletExternalId SetNewExternalId(string? newExternalId)
    {
        return SetVariable("newExternalId", CoreTypes.String, newExternalId);
    }

    /// <summary>
    /// Sets the wallet account on the blockchain.
    /// </summary>
    /// <param name="account">The wallet account.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateWalletExternalId SetAccount(string? account)
    {
        return SetVariable("account", CoreTypes.String, account);
    }
}