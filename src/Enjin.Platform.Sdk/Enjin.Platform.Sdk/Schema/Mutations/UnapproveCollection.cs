using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation removing the approval of any specific account to make transfers from a collection
/// account.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class UnapproveCollection : GraphQlRequest<UnapproveCollection, TransactionFragment>,
                                   IHasIdempotencyKey<UnapproveCollection>,
                                   IHasSkipValidation<UnapproveCollection>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnapproveCollection"/> class.
    /// </summary>
    public UnapproveCollection() : base("UnapproveCollection", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the ID of the collection that approval will be removed from.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public UnapproveCollection SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the account that collection approval will be removed from.
    /// </summary>
    /// <param name="op">The account.</param>
    /// <returns>This request for chaining.</returns>
    public UnapproveCollection SetOperator(string? op)
    {
        return SetVariable("operator", CoreTypes.String, op);
    }
}