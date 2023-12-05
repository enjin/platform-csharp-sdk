using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for creating a new token in a collection.
/// </summary>
/// <remarks>
/// The new token will be automatically transferred to the specified recipient account.
/// </remarks>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class CreateToken : GraphQlRequest<CreateToken, TransactionFragment>,
                           IHasIdempotencyKey<CreateToken>,
                           IHasSkipValidation<CreateToken>,
                           IHasSigningAccount<CreateToken>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateToken"/> class.
    /// </summary>
    public CreateToken() : base("CreateToken", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the recipient account of the tokens for the initial mint.
    /// </summary>
    /// <param name="recipient">The recipient account.</param>
    /// <returns>This request for chaining.</returns>
    public CreateToken SetRecipient(string? recipient)
    {
        return SetVariable("recipient", CoreTypes.String, recipient);
    }

    /// <summary>
    /// Sets the collection ID to create this token in.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public CreateToken SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the parameters to create the token.
    /// </summary>
    /// <param name="parameters">The parameters.</param>
    /// <returns>This request for chaining.</returns>
    public CreateToken SetParams(CreateTokenParams? parameters)
    {
        return SetVariable("params", CoreTypes.CreateTokenParams, parameters);
    }
}