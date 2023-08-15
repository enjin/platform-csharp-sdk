using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for updating a transaction with a new state, transaction ID, and transaction hash.
/// </summary>
/// <remarks>
/// The transaction ID and transaction hash are immutable once set.
/// </remarks>
[PublicAPI]
public class UpdateTransaction : GraphQlRequest<UpdateTransaction>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateTransaction"/> class.
    /// </summary>
    public UpdateTransaction() : base("UpdateTransaction", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the internal ID of the transaction.
    /// </summary>
    /// <param name="id">The internal ID.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateTransaction SetId(int? id)
    {
        return SetVariable("id", CoreTypes.Int, id);
    }

    /// <summary>
    /// Sets the new state of the transaction.
    /// </summary>
    /// <param name="state">The new state.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateTransaction SetState(TransactionState? state)
    {
        return SetVariable("state", CoreTypes.TransactionState, state);
    }

    /// <summary>
    /// Sets the on-chain transaction ID.
    /// </summary>
    /// <param name="transactionId">The transaction ID.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateTransaction SetTransactionId(string? transactionId)
    {
        return SetVariable("transactionId", CoreTypes.String, transactionId);
    }

    /// <summary>
    /// Sets the on-chain transaction hash.
    /// </summary>
    /// <param name="transactionHash">The transaction hash.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateTransaction SetTransactionHash(string? transactionHash)
    {
        return SetVariable("transactionHash", CoreTypes.String, transactionHash);
    }

    /// <summary>
    /// Sets the signing wallet for the transaction.
    /// </summary>
    /// <param name="signingAccount">The signing wallet account.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateTransaction SetSigningAccount(string? signingAccount)
    {
        return SetVariable("signingAccount", CoreTypes.String, signingAccount);
    }

    /// <summary>
    /// Sets the block number the transaction was signed at.
    /// </summary>
    /// <param name="signedAtBlock">The block number.</param>
    /// <returns>This request for chaining.</returns>
    public UpdateTransaction SetSignedAtBlock(int? signedAtBlock)
    {
        return SetVariable("signedAtBlock", CoreTypes.Int, signedAtBlock);
    }
}