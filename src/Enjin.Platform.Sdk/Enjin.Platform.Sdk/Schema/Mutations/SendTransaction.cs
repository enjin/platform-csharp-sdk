using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Update a transaction with a new state, transaction ID and transaction hash. Please note that the transaction ID and transaction hash are immutable once set.
/// </summary>
/// <remarks>
/// 
/// </remarks>
[PublicAPI]
public class SendTransaction : GraphQlRequest<SendTransaction>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SendTransaction"/> class.
    /// </summary>
    public SendTransaction() : base("SendTransaction", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the internal ID of the transaction.
    /// </summary>
    /// <param name="id">The internal ID.</param>
    /// <returns>This request for chaining.</returns>
    public SendTransaction SetId(int? id)
    {
        return SetVariable("id", CoreTypes.Int, id);
    }

    /// <summary>
    /// The signature for the payload.
    /// </summary>
    /// <param name="signature">The signature for the payload.</param>
    /// <returns>This request for chaining.</returns>
    public SendTransaction SetSignature(string? signature)
    {
        return SetVariable("signature", CoreTypes.String, signature);
    }

    /// <summary>
    /// The payload that has been signed.
    /// </summary>
    /// <param name="signingPayloadJson">The transaction ID.</param>
    /// <returns>This request for chaining.</returns>
    public SendTransaction SetSigningPayloadJson(object? signingPayloadJson)
    {
        return SetVariable("signingPayloadJson", "Object!", signingPayloadJson);
    }

}