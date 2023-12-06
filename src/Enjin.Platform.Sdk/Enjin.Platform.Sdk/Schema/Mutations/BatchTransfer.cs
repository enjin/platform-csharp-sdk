using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for transferring multiple tokens in one transaction.
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
public class BatchTransfer : GraphQlRequest<BatchTransfer, TransactionFragment>,
                             IHasContinueOnFailure<BatchTransfer>,
                             IHasIdempotencyKey<BatchTransfer>,
                             IHasSkipValidation<BatchTransfer>,
                             IHasSigningAccount<BatchTransfer>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BatchTransfer"/> class.
    /// </summary>
    public BatchTransfer() : base("BatchTransfer", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the collection ID.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public BatchTransfer SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the recipients for the transfer.
    /// </summary>
    /// <param name="recipients">The recipients.</param>
    /// <returns>This request for chaining.</returns>
    public BatchTransfer SetRecipients(params TransferRecipient[]? recipients)
    {
        return SetVariable("recipients", CoreTypes.TransferRecipientArray, recipients);
    }

    /// <summary>
    /// Sets the signing wallet for the transaction.
    /// </summary>
    /// <param name="signingAccount">The signing wallet account.</param>
    /// <returns>This request for chaining.</returns>
    /// <remarks>
    /// The account defaults to wallet daemon if not specified.
    /// </remarks>
    public BatchTransfer SetSigningAccount(string? signingAccount)
    {
        return SetVariable("signingAccount", CoreTypes.String, signingAccount);
    }
}