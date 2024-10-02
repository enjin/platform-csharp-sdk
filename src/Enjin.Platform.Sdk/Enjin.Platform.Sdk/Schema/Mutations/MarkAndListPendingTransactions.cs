using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A requesting to act as a mutation for getting a list of new pending transactions and marking them as processing.
/// </summary>
/// <seealso cref="Connection{T}"/>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class MarkAndListPendingTransactions
    : GraphQlRequest<MarkAndListPendingTransactions, TransactionConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarkAndListPendingTransactions"/> class.
    /// </summary>
    public MarkAndListPendingTransactions() : base("MarkAndListPendingTransactions", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the accounts to filter the transactions.
    /// </summary>
    /// <param name="accounts">The accounts to filter.</param>
    /// <returns>This request for chaining.</returns>
    public MarkAndListPendingTransactions SetAccounts(params string[]? accounts)
    {
        return SetVariable("accounts", CoreTypes.StringArray, accounts);
    }

    /// <summary>
    /// Sets the network to filter to.
    /// </summary>
    /// <param name="network">The network.</param>
    /// <returns>The request for chaining.</returns>
    public MarkAndListPendingTransactions SetNetwork(string? network)
    {
        return SetVariable("network", CoreTypes.String, network);
    }
    
    /// <summary>
    /// Sets whether the transactions are to be marked as processing. Defaults to <c>true</c> if not specified.
    /// </summary>
    /// <param name="markAsProcessing">Whether the transactions are to be marked as processing.</param>
    /// <returns>This request for chaining.</returns>
    public MarkAndListPendingTransactions SetMarkAsProcessing(bool? markAsProcessing)
    {
        return SetVariable("markAsProcessing", CoreTypes.Boolean, markAsProcessing);
    }
}