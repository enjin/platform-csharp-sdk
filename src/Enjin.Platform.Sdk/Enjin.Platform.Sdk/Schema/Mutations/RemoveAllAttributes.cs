using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for removing all attributes from the given collection or token.
/// </summary>
[PublicAPI]
public class RemoveAllAttributes : GraphQlRequest<RemoveAllAttributes, TransactionFragment>,
                                   IHasEncodableTokenId<RemoveAllAttributes>,
                                   IHasIdempotencyKey<RemoveAllAttributes>,
                                   IHasSkipValidation<RemoveAllAttributes>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveAllAttributes"/> class.
    /// </summary>
    public RemoveAllAttributes() : base("RemoveAllAttributes", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the ID of the collection to remove attributes from.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveAllAttributes SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the attribute count used to calculate the weight of the on-chain extrinsic.
    /// </summary>
    /// <param name="attributeCount">The attribute count.</param>
    /// <returns>This request for chaining.</returns>
    /// <remarks>
    /// This is an advanced feature and is used to calculate the weight of the on-chain extrinsic. Putting a value in
    /// that is not equal to the on-chain attribute count will lead to the transaction failing. When empty, the
    /// attribute count will be auto calculated from data stored in the local database.
    /// </remarks>
    public RemoveAllAttributes SetAttributeCount(int? attributeCount)
    {
        return SetVariable("attributeCount", CoreTypes.Int, attributeCount);
    }
}