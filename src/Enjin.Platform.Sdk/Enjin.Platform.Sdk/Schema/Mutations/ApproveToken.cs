using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for approving another account to make transfers from a token account.
/// </summary>
/// <remarks>
/// The block number where this approval will expire and the amount of tokens this account will be able to transfer may
/// be specified.
/// </remarks>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class ApproveToken : GraphQlRequest<ApproveToken, TransactionFragment>,
                            IHasEncodableTokenId<ApproveToken>,
                            IHasIdempotencyKey<ApproveToken>,
                            IHasSkipValidation<ApproveToken>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApproveToken"/> class.
    /// </summary>
    public ApproveToken() : base("ApproveToken", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the ID of the collection that the token being approved belongs to.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public ApproveToken SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the account that will be approved to operate the token.
    /// </summary>
    /// <param name="op">The account to become an operator.</param>
    /// <returns>This request for chaining.</returns>
    public ApproveToken SetOperator(string? op)
    {
        return SetVariable("operator", CoreTypes.String, op);
    }

    /// <summary>
    /// Sets the amount of tokens that will be approved to operate.
    /// </summary>
    /// <param name="amount">The amount to approve.</param>
    /// <returns>This request for chaining.</returns>
    public ApproveToken SetAmount(BigInteger? amount)
    {
        return SetVariable("amount", CoreTypes.BigInt, amount);
    }

    /// <summary>
    /// Sets the current amount of tokens the operator has.
    /// </summary>
    /// <param name="currentAmount">The current amount approved.</param>
    /// <returns>This request for chaining.</returns>
    public ApproveToken SetCurrentAmount(BigInteger? currentAmount)
    {
        return SetVariable("currentAmount", CoreTypes.BigInt, currentAmount);
    }

    /// <summary>
    /// Sets the block number where the approval will expire.
    /// </summary>
    /// <param name="expiration">The block number.</param>
    /// <returns>This request for chaining.</returns>
    /// <remarks>
    /// If this parameter is <c>null</c> or otherwise unspecified, then the approval will not expire.
    /// </remarks>
    public ApproveToken SetExpiration(int? expiration)
    {
        return SetVariable("expiration", CoreTypes.Int, expiration);
    }
}