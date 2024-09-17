using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for approving another account to transfer any tokens from a collection account.
/// </summary>
/// <remarks>
/// The block number where this approval will expire may be specified.
/// </remarks>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class AcceptCollectionTransfer : GraphQlRequest<AcceptCollectionTransfer, TransactionFragment>,
                                 IHasIdempotencyKey<AcceptCollectionTransfer>,
                                 IHasSkipValidation<AcceptCollectionTransfer>,
                                 IHasSigningAccount<AcceptCollectionTransfer>,
                                 IHasSimulate<AcceptCollectionTransfer>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApproveCollection"/> class.
    /// </summary>
    public AcceptCollectionTransfer() : base("ApproveCollection", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the ID of the collection that will be accepted.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public AcceptCollectionTransfer SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }
}