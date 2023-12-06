using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for transferring all balances of one account to another.
/// </summary>
/// <remarks>
/// The parameter set through the <see cref="SetKeepAlive"/> method may be passed to check if the account will be left
/// with at least the existential deposit.
/// </remarks>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class TransferAllBalance : GraphQlRequest<TransferAllBalance, TransactionFragment>,
                                  IHasIdempotencyKey<TransferAllBalance>,
                                  IHasSkipValidation<TransferAllBalance>,
                                  IHasSigningAccount<TransferAllBalance>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TransferAllBalance"/> class.
    /// </summary>
    public TransferAllBalance() : base("TransferAllBalance", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the recipient account that will receive the transfer.
    /// </summary>
    /// <param name="recipient">The recipient account.</param>
    /// <returns>This request for chaining.</returns>
    public TransferAllBalance SetRecipient(string? recipient)
    {
        return SetVariable("recipient", CoreTypes.String, recipient);
    }

    /// <summary>
    /// Sets whether the transaction will be kept from failing if the balance drops below the minimum requirement.
    /// </summary>
    /// <param name="keepAlive">Whether the transaction will be kept from failing.</param>
    /// <returns>This request for chaining.</returns>
    /// <remarks>
    /// The parameter defaults to <c>false</c> if not set.
    /// </remarks>
    public TransferAllBalance SetKeepAlive(bool? keepAlive)
    {
        return SetVariable("keepAlive", CoreTypes.Boolean, keepAlive);
    }

    /// <summary>
    /// Sets the signing wallet for the transaction.
    /// </summary>
    /// <param name="signingAccount">The signing wallet account.</param>
    /// <returns>This request for chaining.</returns>
    /// <remarks>
    /// The account defaults to wallet daemon if not specified.
    /// </remarks>
    public TransferAllBalance SetSigningAccount(string? signingAccount)
    {
        return SetVariable("signingAccount", CoreTypes.String, signingAccount);
    }
}