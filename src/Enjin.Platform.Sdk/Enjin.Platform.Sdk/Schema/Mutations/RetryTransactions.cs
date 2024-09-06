using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for removing an attribute from the specified token.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class RetryTransactions : GraphQlRequest<RetryTransactions, TransactionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveTokenAttribute"/> class.
    /// </summary>
    public RetryTransactions() : base("RetryTransactions", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the IDs.
    /// </summary>
    /// <param name="ids">The IDs.</param>
    /// <returns>This request for chaining.</returns>
    public RetryTransactions SetCollectionId(BigInteger[]? ids)
    {
        return SetVariable("ids", CoreTypes.BigIntArray, ids);
    }

    /// <summary>
    /// Sets the idempotency keys.
    /// </summary>
    /// <param name="idempotencyKeys">The idempotency keys.</param>
    /// <returns>This request for chaining.</returns>
    public RetryTransactions SetKey(string[]? idempotencyKeys)
    {
        return SetVariable("idempotencyKeys", CoreTypes.StringArray, idempotencyKeys);
    }
}