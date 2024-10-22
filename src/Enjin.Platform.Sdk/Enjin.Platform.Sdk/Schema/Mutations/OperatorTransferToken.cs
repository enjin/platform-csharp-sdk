using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for transferring tokens as the operator of another user's wallet.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class OperatorTransferToken : GraphQlRequest<OperatorTransferToken, TransactionFragment>,
                                     IHasIdempotencyKey<OperatorTransferToken>,
                                     IHasSkipValidation<OperatorTransferToken>,
                                     IHasSigningAccount<OperatorTransferToken>,
                                     IHasSimulate<OperatorTransferToken>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OperatorTransferToken"/> class.
    /// </summary>
    public OperatorTransferToken() : base("OperatorTransferToken", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the collection ID.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public OperatorTransferToken SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the recipient account that will receive the transfer.
    /// </summary>
    /// <param name="recipient">The recipient account.</param>
    /// <returns>This request for chaining.</returns>
    public OperatorTransferToken SetRecipient(string? recipient)
    {
        return SetVariable("recipient", CoreTypes.String, recipient);
    }

    /// <summary>
    /// Sets the parameters for the transfer.
    /// </summary>
    /// <param name="parameters">The parameters.</param>
    /// <returns>This request for chaining.</returns>
    public OperatorTransferToken SetParams(OperatorTransferParams? parameters)
    {
        return SetVariable("params", CoreTypes.OperatorTransferParams, parameters);
    }
}