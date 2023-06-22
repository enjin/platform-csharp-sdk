using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for querying a transaction using its database ID, on-chain transaction ID, or transaction hash.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class GetTransaction : GraphQlRequest<GetTransaction, TransactionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetTransaction"/> class.
    /// </summary>
    public GetTransaction() : base("GetTransaction", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the internal ID of the transaction.
    /// </summary>
    /// <param name="id">The internal ID.</param>
    /// <returns>This request for chaining.</returns>
    public GetTransaction SetId(BigInteger? id)
    {
        return SetVariable("id", CoreTypes.BigInt, id);
    }

    /// <summary>
    /// Sets the idempotency key to filter to.
    /// </summary>
    /// <param name="idempotencyKey">The idempotency key.</param>
    /// <returns>This request for chaining.</returns>
    public GetTransaction SetIdempotencyKey(string? idempotencyKey)
    {
        return SetVariable("idempotencyKey", CoreTypes.String, idempotencyKey);
    }

    /// <summary>
    /// Sets the blockchain transaction ID.
    /// </summary>
    /// <param name="transactionId">The transaction ID.</param>
    /// <returns>This request for chaining.</returns>
    public GetTransaction SetTransactionId(string? transactionId)
    {
        return SetVariable("transactionId", CoreTypes.String, transactionId);
    }

    /// <summary>
    /// Sets the blockchain transaction hash.
    /// </summary>
    /// <param name="transactionHash">The transaction hash.</param>
    /// <returns>This request for chaining.</returns>
    public GetTransaction SetTransactionHash(string? transactionHash)
    {
        return SetVariable("transactionHash", CoreTypes.String, transactionHash);
    }
}