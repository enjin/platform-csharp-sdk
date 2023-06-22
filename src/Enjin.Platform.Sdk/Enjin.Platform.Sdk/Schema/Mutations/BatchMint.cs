using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for minting multiple tokens in one transaction.
/// </summary>
/// <remarks>
/// <para>
/// The create token and mint token params of <see cref="MintRecipient"/> may be mixed and matched.
/// </para>
/// <para>
/// The <c>continueOnFailure</c> flag may be used to skip mints which fail on-chain so that they may be fixed later.
/// </para>
/// </remarks>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class BatchMint : GraphQlRequest<BatchMint, TransactionFragment>,
                         IHasContinueOnFailure<BatchMint>,
                         IHasIdempotencyKey<BatchMint>,
                         IHasSkipValidation<BatchMint>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BatchMint"/> class.
    /// </summary>
    public BatchMint() : base("BatchMint", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the collection ID.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public BatchMint SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the recipients.
    /// </summary>
    /// <param name="recipients">The recipients.</param>
    /// <returns>This request for chaining.</returns>
    public BatchMint SetRecipients(params MintRecipient[]? recipients)
    {
        return SetVariable("recipients", CoreTypes.MintRecipientArray, recipients);
    }
}