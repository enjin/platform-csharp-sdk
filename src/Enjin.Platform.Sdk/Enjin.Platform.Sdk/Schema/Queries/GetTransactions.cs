using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for querying an array of transactions optionally filtered by transaction IDs, transaction hashes, methods,
/// states, results, or accounts.
/// </summary>
/// <seealso cref="Connection{T}"/>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class GetTransactions : GraphQlRequest<GetTransactions, TransactionConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetTransactions"/> class.
    /// </summary>
    public GetTransactions() : base("GetTransactions", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the idempotency keys to filter to.
    /// </summary>
    /// <param name="idempotencyKeys">The idempotency keys.</param>
    /// <returns>This request for chaining.</returns>
    public GetTransactions SetIdempotencyKeys(params string[]? idempotencyKeys)
    {
        return SetVariable("idempotencyKeys", CoreTypes.StringArray, idempotencyKeys);
    }

    /// <summary>
    /// Sets the blockchain transaction IDs to filter to.
    /// </summary>
    /// <param name="transactionIds">The transaction IDs.</param>
    /// <returns>This request for chaining.</returns>
    public GetTransactions SetTransactionIds(params string[]? transactionIds)
    {
        return SetVariable("transactionIds", CoreTypes.StringArray, transactionIds);
    }

    /// <summary>
    /// Sets the blockchain internal IDs to filter to.
    /// </summary>
    /// <param name="ids">The internal IDs of the transaction.</param>
    /// <returns>This request for chaining.</returns>
    public GetTransactions SetIds(params BigInteger[]? ids)
    {
        return SetVariable("ids", CoreTypes.BigIntArray, ids);
    }

    /// <summary>
    /// Sets the blockchain transaction hashes to filter to.
    /// </summary>
    /// <param name="transactionHashes">The transaction hashes.</param>
    /// <returns>This request for chaining.</returns>
    public GetTransactions SetTransactionHashes(params string[]? transactionHashes)
    {
        return SetVariable("transactionHashes", CoreTypes.StringArray, transactionHashes);
    }

    /// <summary>
    /// Sets the transaction methods to filter to.
    /// </summary>
    /// <param name="methods">The transaction methods.</param>
    /// <returns>This request for chaining.</returns>
    public GetTransactions SetMethods(params TransactionMethod[]? methods)
    {
        return SetVariable("methods", CoreTypes.TransactionMethodArray, methods);
    }

    /// <summary>
    /// Sets the transaction states to filter to.
    /// </summary>
    /// <param name="states">The transaction states.</param>
    /// <returns>This request for chaining.</returns>
    public GetTransactions SetStates(params TransactionState[]? states)
    {
        return SetVariable("states", CoreTypes.TransactionStateArray, states);
    }

    /// <summary>
    /// Sets the transaction results to filter to.
    /// </summary>
    /// <param name="results">The transaction results.</param>
    /// <returns>This request for chaining.</returns>
    public GetTransactions SetResults(params TransactionResult[]? results)
    {
        return SetVariable("results", CoreTypes.TransactionResultArray, results);
    }

    /// <summary>
    /// Sets the wallet accounts to filter to.
    /// </summary>
    /// <param name="accounts">The wallet accounts.</param>
    /// <returns>This request for chaining.</returns>
    public GetTransactions SetAccounts(params string[]? accounts)
    {
        return SetVariable("accounts", CoreTypes.StringArray, accounts);
    }
}