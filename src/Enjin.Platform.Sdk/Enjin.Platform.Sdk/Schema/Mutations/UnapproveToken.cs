using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for removing the approval of any specific account to make transfers from a token
/// account.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class UnapproveToken : GraphQlRequest<UnapproveToken, TransactionFragment>,
                              IHasEncodableTokenId<UnapproveToken>,
                              IHasIdempotencyKey<UnapproveToken>,
                              IHasSkipValidation<UnapproveToken>,
                              IHasSigningAccount<UnapproveToken>,
                              IHasSimulate<UnapproveToken>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnapproveToken"/> class.
    /// </summary>
    public UnapproveToken() : base("UnapproveToken", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the ID of the collection that the token belongs to.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public UnapproveToken SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the account that token approval will be removed from.
    /// </summary>
    /// <param name="op">The account.</param>
    /// <returns>This request for chaining.</returns>
    public UnapproveToken SetOperator(string? op)
    {
        return SetVariable("operator", CoreTypes.String, op);
    }
}