using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for setting an attribute on a token.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class SetTokenAttribute : GraphQlRequest<SetTokenAttribute, TransactionFragment>,
                                 IHasEncodableTokenId<SetTokenAttribute>,
                                 IHasIdempotencyKey<SetTokenAttribute>,
                                 IHasSkipValidation<SetTokenAttribute>,
                                 IHasSigningAccount<SetTokenAttribute>,
                                 IHasSimulate<SetTokenAttribute>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SetTokenAttribute"/> class.
    /// </summary>
    public SetTokenAttribute() : base("SetTokenAttribute", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the collection ID.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public SetTokenAttribute SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the attribute key.
    /// </summary>
    /// <param name="key">The attribute key.</param>
    /// <returns>This request for chaining.</returns>
    public SetTokenAttribute SetKey(string? key)
    {
        return SetVariable("key", CoreTypes.String, key);
    }

    /// <summary>
    /// Sets the attribute value.
    /// </summary>
    /// <param name="value">The attribute value.</param>
    /// <returns>This request for chaining.</returns>
    public SetTokenAttribute SetValue(string? value)
    {
        return SetVariable("value", CoreTypes.String, value);
    }
}