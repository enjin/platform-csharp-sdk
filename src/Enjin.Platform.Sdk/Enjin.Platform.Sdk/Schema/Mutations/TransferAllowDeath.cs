using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for transferring a balance of one account to another
/// without checking if the account will be left with at least the existential deposit.
/// </summary>
/// <remarks>
/// Use the TransferKeepAlive mutation to check the balance during the transfer to ensure
/// the account will be left with the keep the existential deposit required to keep the account alive.
/// </remarks>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class TransferAllowDeath : GraphQlRequest<TransferAllowDeath, TransactionFragment>,
                                  IHasIdempotencyKey<TransferAllowDeath>,
                                  IHasSkipValidation<TransferAllowDeath>,
                                  IHasSigningAccount<TransferAllowDeath>,
                                  IHasSimulate<TransferAllowDeath>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TransferAllowDeath"/> class.
    /// </summary>
    public TransferAllowDeath() : base("TransferAllowDeath", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the recipient account that will receive the transfer.
    /// </summary>
    /// <param name="recipient">The recipient account.</param>
    /// <returns>This request for chaining.</returns>
    public TransferAllowDeath SetRecipient(string? recipient)
    {
        return SetVariable("recipient", CoreTypes.String, recipient);
    }
    
    /// <summary>
    /// Sets the amount to transfer.
    /// </summary>
    /// <param name="amount">The recipient account.</param>
    /// <returns>This request for chaining.</returns>
    public TransferAllowDeath SetAmount(BigInteger? amount)
    {
        return SetVariable("amount", CoreTypes.BigInt, amount);
    }
}