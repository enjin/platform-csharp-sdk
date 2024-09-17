using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for transferring multiple balances in one transaction.
/// </summary>
/// <remarks>
/// <para>
/// Up to 250 different transfers per batch may be included.
/// </para>
/// <para>
/// The <c>continueOnFailure</c> flag may be used to allow all valid transfers to complete while skipping transfers
/// which would fail so that they may be fixed and attempted again in another transaction.
/// </para>
/// </remarks>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class BatchTransferBalance : GraphQlRequest<BatchTransferBalance, TransactionFragment>,
                             IHasContinueOnFailure<BatchTransferBalance>,
                             IHasIdempotencyKey<BatchTransferBalance>,
                             IHasSkipValidation<BatchTransferBalance>,
                             IHasSigningAccount<BatchTransferBalance>,
                             IHasSimulate<BatchTransferBalance>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BatchTransferBalance"/> class.
    /// </summary>
    public BatchTransferBalance() : base("BatchTransferBalance", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the recipients for the transfer.
    /// </summary>
    /// <param name="recipients">The recipients.</param>
    /// <returns>This request for chaining.</returns>
    public BatchTransferBalance SetRecipients(params TransferRecipient[]? recipients)
    {
        return SetVariable("recipients", CoreTypes.TransferRecipientArray, recipients);
    }
}