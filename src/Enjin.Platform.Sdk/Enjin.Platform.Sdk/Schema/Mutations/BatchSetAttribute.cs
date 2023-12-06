using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for setting multiple attributes on a collection or token in one transaction.
/// </summary>
/// <remarks>
/// The <c>continueOnFailure</c> flag may be used to allow all valid attributes to be set while skipping invalid
/// attributes so that they may be fixed and attempted again in another transaction.
/// </remarks>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class BatchSetAttribute : GraphQlRequest<BatchSetAttribute, TransactionFragment>,
                                 IHasContinueOnFailure<BatchSetAttribute>,
                                 IHasEncodableTokenId<BatchSetAttribute>,
                                 IHasIdempotencyKey<BatchSetAttribute>,
                                 IHasSkipValidation<BatchSetAttribute>,
                                 IHasSigningAccount<BatchSetAttribute>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BatchSetAttribute"/> class.
    /// </summary>
    public BatchSetAttribute() : base("BatchSetAttribute", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the collection ID.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public BatchSetAttribute SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the attributes.
    /// </summary>
    /// <param name="attributes">The attributes.</param>
    /// <returns>This request for chaining.</returns>
    public BatchSetAttribute SetAttributes(params AttributeInput[]? attributes)
    {
        return SetVariable("attributes", CoreTypes.AttributeInputArray, attributes);
    }
}