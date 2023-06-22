using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for querying whether a message was verified with the provided public key.
/// </summary>
[PublicAPI]
public class VerifyMessage : GraphQlRequest<VerifyMessage>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VerifyMessage"/> class.
    /// </summary>
    public VerifyMessage() : base("VerifyMessage", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the message that the user signed.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns>This request for chaining.</returns>
    public VerifyMessage SetMessage(string? message)
    {
        return SetVariable("message", CoreTypes.String, message);
    }

    /// <summary>
    /// Sets the signature.
    /// </summary>
    /// <param name="signature">The signature.</param>
    /// <returns>This request for chaining.</returns>
    public VerifyMessage SetSignature(string? signature)
    {
        return SetVariable("signature", CoreTypes.String, signature);
    }

    /// <summary>
    /// Sets the public key of the user.
    /// </summary>
    /// <param name="publicKey">The public key.</param>
    /// <returns>This request for chaining.</returns>
    public VerifyMessage SetPublicKey(string? publicKey)
    {
        return SetVariable("publicKey", CoreTypes.String, publicKey);
    }

    /// <summary>
    /// Sets the crypto type of the signature.
    /// </summary>
    /// <param name="cryptoSignatureType">The signature's crypto type.</param>
    /// <returns>This request for chaining.</returns>
    public VerifyMessage SetCryptoSignatureType(CryptoSignatureType? cryptoSignatureType)
    {
        return SetVariable("cryptoSignatureType", CoreTypes.CryptoSignatureType, cryptoSignatureType);
    }
}