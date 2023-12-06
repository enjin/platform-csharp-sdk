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
public class ApproveCollection : GraphQlRequest<ApproveCollection, TransactionFragment>,
                                 IHasIdempotencyKey<ApproveCollection>,
                                 IHasSkipValidation<ApproveCollection>,
                                 IHasSigningAccount<ApproveCollection>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApproveCollection"/> class.
    /// </summary>
    public ApproveCollection() : base("ApproveCollection", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the ID of the collection that will be approved.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public ApproveCollection SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the account that will be approved to operate the collection.
    /// </summary>
    /// <param name="op">The account to become an operator.</param>
    /// <returns>This request for chaining.</returns>
    public ApproveCollection SetOperator(string? op)
    {
        return SetVariable("operator", CoreTypes.String, op);
    }

    /// <summary>
    /// Sets the block number where the approval will expire.
    /// </summary>
    /// <param name="expiration">The block number.</param>
    /// <returns>This request for chaining.</returns>
    /// <remarks>
    /// If this parameter is <c>null</c> or otherwise unspecified, then the approval will not expire.
    /// </remarks>
    public ApproveCollection SetExpiration(int? expiration)
    {
        return SetVariable("expiration", CoreTypes.Int, expiration);
    }
}