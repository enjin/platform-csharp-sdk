using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for transferring a single token to a recipient account.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class SimpleTransferToken : GraphQlRequest<SimpleTransferToken, TransactionFragment>,
                                   IHasIdempotencyKey<SimpleTransferToken>,
                                   IHasSkipValidation<SimpleTransferToken>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SimpleTransferToken"/> class.
    /// </summary>
    public SimpleTransferToken() : base("SimpleTransferToken", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the collection ID.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public SimpleTransferToken SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the recipient account that will receive the transfer.
    /// </summary>
    /// <param name="recipient">The recipient account.</param>
    /// <returns>This request for chaining.</returns>
    public SimpleTransferToken SetRecipient(string? recipient)
    {
        return SetVariable("recipient", CoreTypes.String, recipient);
    }

    /// <summary>
    /// Sets the parameters for the transfer.
    /// </summary>
    /// <param name="parameters">The parameters.</param>
    /// <returns>This request for chaining.</returns>
    public SimpleTransferToken SetParams(SimpleTransferParams? parameters)
    {
        return SetVariable("params", CoreTypes.SimpleTransferParams, parameters);
    }

    /// <summary>
    /// Sets the signing wallet for the transaction.
    /// </summary>
    /// <param name="signingAccount">The signing wallet account.</param>
    /// <returns>This request for chaining.</returns>
    /// <remarks>
    /// The account defaults to wallet daemon if not specified.
    /// </remarks>
    public SimpleTransferToken SetSigningAccount(string? signingAccount)
    {
        return SetVariable("signingAccount", CoreTypes.String, signingAccount);
    }
}