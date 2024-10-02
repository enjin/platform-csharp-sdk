using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for transferring a balance of one account to another
/// a keep alive check. This mutation is slower than TransferAllowDeath as it checks
/// the account's balance at the blockchain.
/// </summary>
/// <remarks>
/// Use the TransferAllowDeath mutation to transfer without checking the on-chain balance.
/// </remarks>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class TransferKeepAlive : GraphQlRequest<TransferKeepAlive, TransactionFragment>,
                                  IHasIdempotencyKey<TransferKeepAlive>,
                                  IHasSkipValidation<TransferKeepAlive>,
                                  IHasSigningAccount<TransferKeepAlive>,
                                  IHasSimulate<TransferKeepAlive>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TransferKeepAlive"/> class.
    /// </summary>
    public TransferKeepAlive() : base("TransferKeepAlive", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the recipient account that will receive the transfer.
    /// </summary>
    /// <param name="recipient">The recipient account.</param>
    /// <returns>This request for chaining.</returns>
    public TransferKeepAlive SetRecipient(string? recipient)
    {
        return SetVariable("recipient", CoreTypes.String, recipient);
    }
    
    /// <summary>
    /// Sets the amount to transfer.
    /// </summary>
    /// <param name="amount">The recipient account.</param>
    /// <returns>This request for chaining.</returns>
    public TransferKeepAlive SetRecipient(BigInteger? amount)
    {
        return SetVariable("amount", CoreTypes.BigInt, amount);
    }
}