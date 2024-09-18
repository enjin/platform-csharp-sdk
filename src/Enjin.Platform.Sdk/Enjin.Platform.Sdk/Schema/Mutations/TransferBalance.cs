using System;
using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation to transfer a balance from one account to another.
/// </summary>
/// <remarks>
/// The parameter set through the <see cref="SetKeepAlive"/> method may be passed to check if the account will be left
/// with at least the existential deposit.
/// </remarks>
/// <seealso cref="Transaction"/>
[Obsolete("This mutation is deprecated and will be removed in a future release. Use the TransferAllowDeath and TransferKeepAlive mutations instead.")]
[PublicAPI]
public class TransferBalance : GraphQlRequest<TransferBalance, TransactionFragment>,
                               IHasIdempotencyKey<TransferBalance>,
                               IHasSkipValidation<TransferBalance>,
                               IHasSigningAccount<TransferBalance>,
                               IHasSimulate<TransferBalance>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TransferBalance"/> class.
    /// </summary>
    public TransferBalance() : base("TransferBalance", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the recipient account that will receive the transfer.
    /// </summary>
    /// <param name="recipient">The recipient account.</param>
    /// <returns>This request for chaining.</returns>
    public TransferBalance SetRecipient(string? recipient)
    {
        return SetVariable("recipient", CoreTypes.String, recipient);
    }

    /// <summary>
    /// Sets the amount to transfer.
    /// </summary>
    /// <param name="amount">The amount.</param>
    /// <returns>This request for chaining.</returns>
    public TransferBalance SetAmount(BigInteger? amount)
    {
        return SetVariable("amount", CoreTypes.BigInt, amount);
    }

    /// <summary>
    /// Sets whether the transaction will be kept from failing if the balance drops below the minimum requirement.
    /// </summary>
    /// <param name="keepAlive">Whether the transaction will be kept from failing.</param>
    /// <returns>This request for chaining.</returns>
    /// <remarks>
    /// The parameter defaults to <c>false</c> if not set.
    /// </remarks>
    public TransferBalance SetKeepAlive(bool? keepAlive)
    {
        return SetVariable("keepAlive", CoreTypes.Boolean, keepAlive);
    }
}